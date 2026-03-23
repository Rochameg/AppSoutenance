using AppSoutenance.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppSoutenance.Services
{
    /// <summary>
    /// Service pour la gestion des candidats (ADO.NET)
    /// </summary>
    public class CandidatService : BaseServiceADO
    {
        public List<Candidat> GetAll()
        {
            var liste = new List<Candidat>();
            var dt = ExecuteQuery("SELECT * FROM utilisateurs WHERE Discriminator = 'Candidat' ORDER BY NomUtilisateur, PrenomUtilisateur");
            foreach (System.Data.DataRow row in dt.Rows) liste.Add(MapCandidat(row));
            return liste;
        }

        public Candidat GetById(int id)
        {
            var dt = ExecuteQuery("SELECT * FROM utilisateurs WHERE IdUtilisateur = @Id AND Discriminator = 'Candidat'",
                new MySqlParameter("@Id", id));
            return dt.Rows.Count > 0 ? MapCandidat(dt.Rows[0]) : null;
        }

        public List<Candidat> Rechercher(string terme)
        {
            if (string.IsNullOrWhiteSpace(terme)) return GetAll();
            var liste = new List<Candidat>();
            var dt = ExecuteQuery(@"SELECT * FROM utilisateurs WHERE Discriminator = 'Candidat'
                AND (NomUtilisateur LIKE @Terme OR PrenomUtilisateur LIKE @Terme OR MatriculeCandidat LIKE @Terme OR EmailUtilisateur LIKE @Terme)
                ORDER BY NomUtilisateur, PrenomUtilisateur",
                new MySqlParameter("@Terme", $"%{terme}%"));
            foreach (System.Data.DataRow row in dt.Rows) liste.Add(MapCandidat(row));
            return liste;
        }

        public Candidat GetByMatricule(string matricule)
        {
            var dt = ExecuteQuery("SELECT * FROM utilisateurs WHERE MatriculeCandidat = @Mat AND Discriminator = 'Candidat'",
                new MySqlParameter("@Mat", matricule));
            return dt.Rows.Count > 0 ? MapCandidat(dt.Rows[0]) : null;
        }

        public List<ListItem> GetListItems()
        {
            var liste = new List<ListItem> { new ListItem { Value = null, Text = "-- Sélectionner --" } };
            foreach (var c in GetAll())
            {
                liste.Add(new ListItem
                {
                    Value = c.IdUtilisateur.ToString(),
                    Text = $"{c.MatriculeCandidat} - {c.NomUtilisateur} {c.PrenomUtilisateur}"
                });
            }
            return liste;
        }

        private Candidat MapCandidat(System.Data.DataRow row)
        {
            return new Candidat
            {
                IdUtilisateur = Convert.ToInt32(row["IdUtilisateur"]),
                NomUtilisateur = row["NomUtilisateur"]?.ToString() ?? "",
                PrenomUtilisateur = row["PrenomUtilisateur"]?.ToString() ?? "",
                TelUtilisateur = row["TelUtilisateur"]?.ToString() ?? "",
                EmailUtilisateur = row["EmailUtilisateur"]?.ToString() ?? "",
                MotDeUtilisateur = row["MotDeUtilisateur"]?.ToString() ?? "",
                MatriculeCandidat = row["MatriculeCandidat"]?.ToString() ?? ""
            };
        }

        public List<string> Valider(Candidat c)
        {
            var erreurs = new List<string>();
            if (string.IsNullOrWhiteSpace(c.MatriculeCandidat)) erreurs.Add("Le matricule est requis.");
            if (c.MatriculeCandidat?.Length > 20) erreurs.Add("Le matricule ne doit pas dépasser 20 caractères.");
            if (string.IsNullOrWhiteSpace(c.NomUtilisateur)) erreurs.Add("Le nom est requis.");
            if (string.IsNullOrWhiteSpace(c.PrenomUtilisateur)) erreurs.Add("Le prénom est requis.");
            if (string.IsNullOrWhiteSpace(c.EmailUtilisateur)) erreurs.Add("L'email est requis.");
            if (!string.IsNullOrWhiteSpace(c.EmailUtilisateur) && !c.EmailUtilisateur.Contains("@"))
                erreurs.Add("L'email n'est pas valide.");
            if (string.IsNullOrWhiteSpace(c.TelUtilisateur)) erreurs.Add("Le téléphone est requis.");
            if (string.IsNullOrWhiteSpace(c.MotDeUtilisateur)) erreurs.Add("Le mot de passe est requis.");

            var count = Convert.ToInt32(ExecuteScalar(
                "SELECT COUNT(*) FROM utilisateurs WHERE MatriculeCandidat = @Mat AND IdUtilisateur != @Id",
                new MySqlParameter("@Mat", c.MatriculeCandidat ?? ""),
                new MySqlParameter("@Id", c.IdUtilisateur)));
            if (count > 0) erreurs.Add("Ce matricule est déjà utilisé.");

            count = Convert.ToInt32(ExecuteScalar(
                "SELECT COUNT(*) FROM utilisateurs WHERE EmailUtilisateur = @Email AND IdUtilisateur != @Id",
                new MySqlParameter("@Email", c.EmailUtilisateur ?? ""),
                new MySqlParameter("@Id", c.IdUtilisateur)));
            if (count > 0) erreurs.Add("Cet email est déjà utilisé.");
            return erreurs;
        }

        public ServiceResult<Candidat> Add(Candidat entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any()) return ServiceResult<Candidat>.Failure(erreurs);
            try
            {
                ExecuteNonQuery(@"INSERT INTO utilisateurs (NomUtilisateur, PrenomUtilisateur, TelUtilisateur, EmailUtilisateur, MotDeUtilisateur, Discriminator, MatriculeCandidat)
                    VALUES (@Nom, @Prenom, @Tel, @Email, @Pwd, 'Candidat', @Mat)",
                    new MySqlParameter("@Nom", entity.NomUtilisateur),
                    new MySqlParameter("@Prenom", entity.PrenomUtilisateur),
                    new MySqlParameter("@Tel", entity.TelUtilisateur),
                    new MySqlParameter("@Email", entity.EmailUtilisateur),
                    new MySqlParameter("@Pwd", entity.MotDeUtilisateur),
                    new MySqlParameter("@Mat", entity.MatriculeCandidat));
                entity.IdUtilisateur = Convert.ToInt32(ExecuteScalar("SELECT LAST_INSERT_ID()"));
                return ServiceResult<Candidat>.Success(entity, "Candidat ajouté avec succès.");
            }
            catch (Exception ex) { return ServiceResult<Candidat>.Failure($"Erreur : {ex.Message}"); }
        }

        public ServiceResult<Candidat> Update(Candidat entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any()) return ServiceResult<Candidat>.Failure(erreurs);
            try
            {
                ExecuteNonQuery(@"UPDATE utilisateurs SET NomUtilisateur=@Nom, PrenomUtilisateur=@Prenom, TelUtilisateur=@Tel,
                    EmailUtilisateur=@Email, MotDeUtilisateur=@Pwd, MatriculeCandidat=@Mat WHERE IdUtilisateur=@Id",
                    new MySqlParameter("@Nom", entity.NomUtilisateur),
                    new MySqlParameter("@Prenom", entity.PrenomUtilisateur),
                    new MySqlParameter("@Tel", entity.TelUtilisateur),
                    new MySqlParameter("@Email", entity.EmailUtilisateur),
                    new MySqlParameter("@Pwd", entity.MotDeUtilisateur),
                    new MySqlParameter("@Mat", entity.MatriculeCandidat),
                    new MySqlParameter("@Id", entity.IdUtilisateur));
                return ServiceResult<Candidat>.Success(entity, "Candidat modifié avec succès.");
            }
            catch (Exception ex) { return ServiceResult<Candidat>.Failure($"Erreur : {ex.Message}"); }
        }

        public ServiceResult<bool> Delete(int id)
        {
            try
            {
                ExecuteNonQuery("DELETE FROM utilisateurs WHERE IdUtilisateur = @Id", new MySqlParameter("@Id", id));
                return ServiceResult<bool>.Success(true, "Candidat supprimé avec succès.");
            }
            catch (Exception ex) { return ServiceResult<bool>.Failure($"Erreur : {ex.Message}"); }
        }
    }
}
