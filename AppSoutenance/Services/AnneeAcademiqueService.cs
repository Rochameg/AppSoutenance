using AppSoutenance.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppSoutenance.Services
{
    /// <summary>
    /// Service pour la gestion des années académiques (ADO.NET)
    /// </summary>
    public class AnneeAcademiqueService : BaseServiceADO
    {
        /// <summary>
        /// Récupère toutes les années académiques triées par valeur décroissante
        /// </summary>
        public List<AnneeAcademique> GetAll()
        {
            var liste = new List<AnneeAcademique>();
            var dt = ExecuteQuery("SELECT * FROM anneeAcademiques ORDER BY AnneeAcademiqueVal DESC");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(new AnneeAcademique
                {
                    IdAnneeAcademique = Convert.ToInt32(row["IdAnneeAcademique"]),
                    LibelleAnneeAcademique = row["LibelleAnneeAcademique"]?.ToString(),
                    AnneeAcademiqueVal = Convert.ToInt32(row["AnneeAcademiqueVal"])
                });
            }
            return liste;
        }

        /// <summary>
        /// Récupère une année académique par son ID
        /// </summary>
        public AnneeAcademique GetById(int id)
        {
            var dt = ExecuteQuery("SELECT * FROM anneeAcademiques WHERE IdAnneeAcademique = @Id",
                new MySqlParameter("@Id", id));

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new AnneeAcademique
                {
                    IdAnneeAcademique = Convert.ToInt32(row["IdAnneeAcademique"]),
                    LibelleAnneeAcademique = row["LibelleAnneeAcademique"]?.ToString(),
                    AnneeAcademiqueVal = Convert.ToInt32(row["AnneeAcademiqueVal"])
                };
            }
            return null;
        }

        /// <summary>
        /// Recherche par libellé
        /// </summary>
        public List<AnneeAcademique> RechercherParLibelle(string libelle)
        {
            if (string.IsNullOrWhiteSpace(libelle))
                return GetAll();

            var liste = new List<AnneeAcademique>();
            var dt = ExecuteQuery(
                "SELECT * FROM anneeAcademiques WHERE LibelleAnneeAcademique LIKE @Libelle ORDER BY AnneeAcademiqueVal DESC",
                new MySqlParameter("@Libelle", $"%{libelle}%"));

            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(new AnneeAcademique
                {
                    IdAnneeAcademique = Convert.ToInt32(row["IdAnneeAcademique"]),
                    LibelleAnneeAcademique = row["LibelleAnneeAcademique"]?.ToString(),
                    AnneeAcademiqueVal = Convert.ToInt32(row["AnneeAcademiqueVal"])
                });
            }
            return liste;
        }

        /// <summary>
        /// Récupère l'année académique actuelle (la plus récente)
        /// </summary>
        public AnneeAcademique GetAnneeActuelle()
        {
            var dt = ExecuteQuery("SELECT * FROM anneeAcademiques ORDER BY AnneeAcademiqueVal DESC LIMIT 1");

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new AnneeAcademique
                {
                    IdAnneeAcademique = Convert.ToInt32(row["IdAnneeAcademique"]),
                    LibelleAnneeAcademique = row["LibelleAnneeAcademique"]?.ToString(),
                    AnneeAcademiqueVal = Convert.ToInt32(row["AnneeAcademiqueVal"])
                };
            }
            return null;
        }

        /// <summary>
        /// Récupère la liste pour remplir un ComboBox
        /// </summary>
        public List<ListItem> GetListItems()
        {
            var liste = new List<ListItem>
            {
                new ListItem { Value = null, Text = "-- Sélectionner --" }
            };

            foreach (var annee in GetAll())
            {
                liste.Add(new ListItem
                {
                    Value = annee.IdAnneeAcademique.ToString(),
                    Text = annee.LibelleAnneeAcademique
                });
            }

            return liste;
        }

        /// <summary>
        /// Valide une année académique avant sauvegarde
        /// </summary>
        public List<string> Valider(AnneeAcademique annee)
        {
            var erreurs = new List<string>();

            if (string.IsNullOrWhiteSpace(annee.LibelleAnneeAcademique))
                erreurs.Add("Le libellé est requis.");

            if (annee.LibelleAnneeAcademique?.Length > 10)
                erreurs.Add("Le libellé ne doit pas dépasser 10 caractères.");

            if (annee.AnneeAcademiqueVal < 2000 || annee.AnneeAcademiqueVal > 2100)
                erreurs.Add("L'année doit être comprise entre 2000 et 2100.");

            // Vérifier l'unicité du libellé
            var count = Convert.ToInt32(ExecuteScalar(
                "SELECT COUNT(*) FROM anneeAcademiques WHERE LibelleAnneeAcademique = @Libelle AND IdAnneeAcademique != @Id",
                new MySqlParameter("@Libelle", annee.LibelleAnneeAcademique ?? ""),
                new MySqlParameter("@Id", annee.IdAnneeAcademique)));

            if (count > 0)
                erreurs.Add("Ce libellé existe déjà.");

            return erreurs;
        }

        /// <summary>
        /// Ajoute une nouvelle année académique
        /// </summary>
        public ServiceResult<AnneeAcademique> Add(AnneeAcademique entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any())
                return ServiceResult<AnneeAcademique>.Failure(erreurs);

            try
            {
                ExecuteNonQuery(
                    "INSERT INTO anneeAcademiques (LibelleAnneeAcademique, AnneeAcademiqueVal) VALUES (@Libelle, @Val)",
                    new MySqlParameter("@Libelle", entity.LibelleAnneeAcademique),
                    new MySqlParameter("@Val", entity.AnneeAcademiqueVal));

                entity.IdAnneeAcademique = Convert.ToInt32(ExecuteScalar("SELECT LAST_INSERT_ID()"));
                return ServiceResult<AnneeAcademique>.Success(entity, "Année académique ajoutée avec succès.");
            }
            catch (Exception ex)
            {
                return ServiceResult<AnneeAcademique>.Failure($"Erreur lors de l'ajout : {ex.Message}");
            }
        }

        /// <summary>
        /// Met à jour une année académique
        /// </summary>
        public ServiceResult<AnneeAcademique> Update(AnneeAcademique entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any())
                return ServiceResult<AnneeAcademique>.Failure(erreurs);

            try
            {
                ExecuteNonQuery(
                    "UPDATE anneeAcademiques SET LibelleAnneeAcademique = @Libelle, AnneeAcademiqueVal = @Val WHERE IdAnneeAcademique = @Id",
                    new MySqlParameter("@Libelle", entity.LibelleAnneeAcademique),
                    new MySqlParameter("@Val", entity.AnneeAcademiqueVal),
                    new MySqlParameter("@Id", entity.IdAnneeAcademique));

                return ServiceResult<AnneeAcademique>.Success(entity, "Année académique modifiée avec succès.");
            }
            catch (Exception ex)
            {
                return ServiceResult<AnneeAcademique>.Failure($"Erreur lors de la modification : {ex.Message}");
            }
        }

        /// <summary>
        /// Supprime une année académique
        /// </summary>
        public ServiceResult<bool> Delete(int id)
        {
            try
            {
                ExecuteNonQuery("DELETE FROM anneeAcademiques WHERE IdAnneeAcademique = @Id",
                    new MySqlParameter("@Id", id));
                return ServiceResult<bool>.Success(true, "Année académique supprimée avec succès.");
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Erreur lors de la suppression : {ex.Message}");
            }
        }

        /// <summary>
        /// Compte le nombre total
        /// </summary>
        public int Count()
        {
            return Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM anneeAcademiques"));
        }
    }
}
