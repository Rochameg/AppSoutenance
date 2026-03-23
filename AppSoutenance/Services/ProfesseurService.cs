using AppSoutenance.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppSoutenance.Services
{
    /// <summary>
    /// Service pour la gestion des professeurs (ADO.NET)
    /// </summary>
    public class ProfesseurService : BaseServiceADO
    {
        public List<Professeur> GetAll()
        {
            var liste = new List<Professeur>();
            var dt = ExecuteQuery("SELECT * FROM utilisateurs WHERE Discriminator = 'Professeur' ORDER BY NomUtilisateur, PrenomUtilisateur");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(MapProfesseur(row));
            }
            return liste;
        }

        public Professeur GetById(int id)
        {
            var dt = ExecuteQuery("SELECT * FROM utilisateurs WHERE IdUtilisateur = @Id AND Discriminator = 'Professeur'",
                new MySqlParameter("@Id", id));
            return dt.Rows.Count > 0 ? MapProfesseur(dt.Rows[0]) : null;
        }

        public List<Professeur> Rechercher(string terme)
        {
            if (string.IsNullOrWhiteSpace(terme)) return GetAll();
            var liste = new List<Professeur>();
            var dt = ExecuteQuery(@"SELECT * FROM utilisateurs WHERE Discriminator = 'Professeur'
                AND (NomUtilisateur LIKE @Terme OR PrenomUtilisateur LIKE @Terme OR SpecialiteProfesseur LIKE @Terme OR EmailUtilisateur LIKE @Terme)
                ORDER BY NomUtilisateur, PrenomUtilisateur",
                new MySqlParameter("@Terme", $"%{terme}%"));
            foreach (System.Data.DataRow row in dt.Rows) liste.Add(MapProfesseur(row));
            return liste;
        }

        public List<ListItem> GetListItems()
        {
            var liste = new List<ListItem> { new ListItem { Value = null, Text = "-- Sélectionner --" } };
            foreach (var prof in GetAll())
            {
                liste.Add(new ListItem
                {
                    Value = prof.IdUtilisateur.ToString(),
                    Text = $"{prof.NomUtilisateur} {prof.PrenomUtilisateur} ({prof.SpecialiteProfesseur})"
                });
            }
            return liste;
        }

        private Professeur MapProfesseur(System.Data.DataRow row)
        {
            return new Professeur
            {
                IdUtilisateur = Convert.ToInt32(row["IdUtilisateur"]),
                NomUtilisateur = row["NomUtilisateur"]?.ToString() ?? "",
                PrenomUtilisateur = row["PrenomUtilisateur"]?.ToString() ?? "",
                TelUtilisateur = row["TelUtilisateur"]?.ToString() ?? "",
                EmailUtilisateur = row["EmailUtilisateur"]?.ToString() ?? "",
                MotDeUtilisateur = row["MotDeUtilisateur"]?.ToString() ?? "",
                SpecialiteProfesseur = row["SpecialiteProfesseur"]?.ToString() ?? ""
            };
        }

        public List<string> Valider(Professeur prof)
        {
            var erreurs = new List<string>();
            if (string.IsNullOrWhiteSpace(prof.NomUtilisateur)) erreurs.Add("Le nom est requis.");
            if (string.IsNullOrWhiteSpace(prof.PrenomUtilisateur)) erreurs.Add("Le prénom est requis.");
            if (string.IsNullOrWhiteSpace(prof.EmailUtilisateur)) erreurs.Add("L'email est requis.");
            if (!string.IsNullOrWhiteSpace(prof.EmailUtilisateur) && !prof.EmailUtilisateur.Contains("@"))
                erreurs.Add("L'email n'est pas valide.");
            if (string.IsNullOrWhiteSpace(prof.TelUtilisateur)) erreurs.Add("Le téléphone est requis.");
            if (string.IsNullOrWhiteSpace(prof.SpecialiteProfesseur)) erreurs.Add("La spécialité est requise.");
            if (string.IsNullOrWhiteSpace(prof.MotDeUtilisateur)) erreurs.Add("Le mot de passe est requis.");

            var count = Convert.ToInt32(ExecuteScalar(
                "SELECT COUNT(*) FROM utilisateurs WHERE EmailUtilisateur = @Email AND IdUtilisateur != @Id",
                new MySqlParameter("@Email", prof.EmailUtilisateur ?? ""),
                new MySqlParameter("@Id", prof.IdUtilisateur)));
            if (count > 0) erreurs.Add("Cet email est déjà utilisé.");
            return erreurs;
        }

        public ServiceResult<Professeur> Add(Professeur entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any()) return ServiceResult<Professeur>.Failure(erreurs);
            try
            {
                ExecuteNonQuery(@"INSERT INTO utilisateurs (NomUtilisateur, PrenomUtilisateur, TelUtilisateur, EmailUtilisateur, MotDeUtilisateur, Discriminator, SpecialiteProfesseur)
                    VALUES (@Nom, @Prenom, @Tel, @Email, @Pwd, 'Professeur', @Specialite)",
                    new MySqlParameter("@Nom", entity.NomUtilisateur),
                    new MySqlParameter("@Prenom", entity.PrenomUtilisateur),
                    new MySqlParameter("@Tel", entity.TelUtilisateur),
                    new MySqlParameter("@Email", entity.EmailUtilisateur),
                    new MySqlParameter("@Pwd", entity.MotDeUtilisateur),
                    new MySqlParameter("@Specialite", entity.SpecialiteProfesseur));
                entity.IdUtilisateur = Convert.ToInt32(ExecuteScalar("SELECT LAST_INSERT_ID()"));
                return ServiceResult<Professeur>.Success(entity, "Professeur ajouté avec succès.");
            }
            catch (Exception ex) { return ServiceResult<Professeur>.Failure($"Erreur : {ex.Message}"); }
        }

        public ServiceResult<Professeur> Update(Professeur entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any()) return ServiceResult<Professeur>.Failure(erreurs);
            try
            {
                ExecuteNonQuery(@"UPDATE utilisateurs SET NomUtilisateur=@Nom, PrenomUtilisateur=@Prenom, TelUtilisateur=@Tel,
                    EmailUtilisateur=@Email, MotDeUtilisateur=@Pwd, SpecialiteProfesseur=@Specialite WHERE IdUtilisateur=@Id",
                    new MySqlParameter("@Nom", entity.NomUtilisateur),
                    new MySqlParameter("@Prenom", entity.PrenomUtilisateur),
                    new MySqlParameter("@Tel", entity.TelUtilisateur),
                    new MySqlParameter("@Email", entity.EmailUtilisateur),
                    new MySqlParameter("@Pwd", entity.MotDeUtilisateur),
                    new MySqlParameter("@Specialite", entity.SpecialiteProfesseur),
                    new MySqlParameter("@Id", entity.IdUtilisateur));
                return ServiceResult<Professeur>.Success(entity, "Professeur modifié avec succès.");
            }
            catch (Exception ex) { return ServiceResult<Professeur>.Failure($"Erreur : {ex.Message}"); }
        }

        public ServiceResult<bool> Delete(int id)
        {
            try
            {
                ExecuteNonQuery("DELETE FROM utilisateurs WHERE IdUtilisateur = @Id", new MySqlParameter("@Id", id));
                return ServiceResult<bool>.Success(true, "Professeur supprimé avec succès.");
            }
            catch (Exception ex) { return ServiceResult<bool>.Failure($"Erreur : {ex.Message}"); }
        }
    }
}
