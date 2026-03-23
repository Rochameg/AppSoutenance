using AppSoutenance.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppSoutenance.Services
{
    /// <summary>
    /// Service pour la gestion des mémoires (ADO.NET)
    /// </summary>
    public class MemoireService : BaseServiceADO
    {
        /// <summary>
        /// Récupère tous les mémoires avec les relations
        /// </summary>
        public List<Memoire> GetAll()
        {
            var liste = new List<Memoire>();
            var dt = ExecuteQuery(@"
                SELECT m.*,
                       a.LibelleAnneeAcademique, a.AnneeAcademiqueVal,
                       s.LibelleSession
                FROM memoires m
                LEFT JOIN anneeAcademiques a ON m.IdAnneeAcademique = a.IdAnneeAcademique
                LEFT JOIN sessions s ON m.IdSession = s.IdSession
                ORDER BY a.AnneeAcademiqueVal DESC, m.SujetMemoire");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(MapMemoire(row));
            }
            return liste;
        }

        /// <summary>
        /// Récupère un mémoire par ID avec les relations
        /// </summary>
        public Memoire GetById(int id)
        {
            var dt = ExecuteQuery(@"
                SELECT m.*,
                       a.LibelleAnneeAcademique, a.AnneeAcademiqueVal,
                       s.LibelleSession
                FROM memoires m
                LEFT JOIN anneeAcademiques a ON m.IdAnneeAcademique = a.IdAnneeAcademique
                LEFT JOIN sessions s ON m.IdSession = s.IdSession
                WHERE m.IdMemoire = @Id", new MySqlParameter("@Id", id));

            if (dt.Rows.Count > 0)
            {
                return MapMemoire(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Récupère les mémoires d'une année académique
        /// </summary>
        public List<Memoire> GetByAnneeAcademique(int idAnneeAcademique)
        {
            var liste = new List<Memoire>();
            var dt = ExecuteQuery(@"
                SELECT m.*,
                       a.LibelleAnneeAcademique, a.AnneeAcademiqueVal,
                       s.LibelleSession
                FROM memoires m
                LEFT JOIN anneeAcademiques a ON m.IdAnneeAcademique = a.IdAnneeAcademique
                LEFT JOIN sessions s ON m.IdSession = s.IdSession
                WHERE m.IdAnneeAcademique = @IdAnnee
                ORDER BY m.SujetMemoire", new MySqlParameter("@IdAnnee", idAnneeAcademique));

            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(MapMemoire(row));
            }
            return liste;
        }

        /// <summary>
        /// Récupère les mémoires d'une session
        /// </summary>
        public List<Memoire> GetBySession(int idSession)
        {
            var liste = new List<Memoire>();
            var dt = ExecuteQuery(@"
                SELECT m.*,
                       a.LibelleAnneeAcademique, a.AnneeAcademiqueVal,
                       s.LibelleSession
                FROM memoires m
                LEFT JOIN anneeAcademiques a ON m.IdAnneeAcademique = a.IdAnneeAcademique
                LEFT JOIN sessions s ON m.IdSession = s.IdSession
                WHERE m.IdSession = @IdSession
                ORDER BY m.SujetMemoire", new MySqlParameter("@IdSession", idSession));

            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(MapMemoire(row));
            }
            return liste;
        }

        /// <summary>
        /// Recherche par sujet
        /// </summary>
        public List<Memoire> Rechercher(string sujet = null, int? idAnneeAcademique = null, int? idSession = null)
        {
            var liste = new List<Memoire>();
            var parameters = new List<MySqlParameter>();

            string query = @"
                SELECT m.*,
                       a.LibelleAnneeAcademique, a.AnneeAcademiqueVal,
                       s.LibelleSession
                FROM memoires m
                LEFT JOIN anneeAcademiques a ON m.IdAnneeAcademique = a.IdAnneeAcademique
                LEFT JOIN sessions s ON m.IdSession = s.IdSession
                WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(sujet))
            {
                query += " AND m.SujetMemoire LIKE @Sujet";
                parameters.Add(new MySqlParameter("@Sujet", $"%{sujet}%"));
            }

            if (idAnneeAcademique.HasValue)
            {
                query += " AND m.IdAnneeAcademique = @IdAnnee";
                parameters.Add(new MySqlParameter("@IdAnnee", idAnneeAcademique.Value));
            }

            if (idSession.HasValue)
            {
                query += " AND m.IdSession = @IdSession";
                parameters.Add(new MySqlParameter("@IdSession", idSession.Value));
            }

            query += " ORDER BY a.AnneeAcademiqueVal DESC, m.SujetMemoire";

            var dt = ExecuteQuery(query, parameters.ToArray());
            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(MapMemoire(row));
            }
            return liste;
        }

        /// <summary>
        /// Récupère la liste pour remplir un ComboBox
        /// </summary>
        public List<ListItem> GetListItems(int? idSession = null)
        {
            var liste = new List<ListItem>
            {
                new ListItem { Value = null, Text = "-- Sélectionner --" }
            };

            string query = "SELECT IdMemoire, SujetMemoire FROM memoires";
            var parameters = new List<MySqlParameter>();

            if (idSession.HasValue)
            {
                query += " WHERE IdSession = @IdSession";
                parameters.Add(new MySqlParameter("@IdSession", idSession.Value));
            }

            query += " ORDER BY SujetMemoire";

            var dt = ExecuteQuery(query, parameters.ToArray());
            foreach (System.Data.DataRow row in dt.Rows)
            {
                var text = row["SujetMemoire"]?.ToString() ?? "";
                if (text.Length > 50)
                    text = text.Substring(0, 47) + "...";

                liste.Add(new ListItem
                {
                    Value = row["IdMemoire"].ToString(),
                    Text = text
                });
            }

            return liste;
        }

        /// <summary>
        /// Valide un mémoire avant sauvegarde
        /// </summary>
        public List<string> Valider(Memoire memoire)
        {
            var erreurs = new List<string>();

            if (string.IsNullOrWhiteSpace(memoire.SujetMemoire))
                erreurs.Add("Le sujet du mémoire est requis.");

            if (memoire.SujetMemoire?.Length > 500)
                erreurs.Add("Le sujet ne doit pas dépasser 500 caractères.");

            if (!memoire.IdAnneeAcademique.HasValue)
                erreurs.Add("L'année académique est requise.");

            if (!memoire.IdSession.HasValue)
                erreurs.Add("La session est requise.");

            return erreurs;
        }

        /// <summary>
        /// Ajoute un mémoire
        /// </summary>
        public ServiceResult<Memoire> Add(Memoire entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any())
                return ServiceResult<Memoire>.Failure(erreurs);

            try
            {
                ExecuteNonQuery(@"
                    INSERT INTO memoires (SujetMemoire, IdAnneeAcademique, IdSession)
                    VALUES (@Sujet, @IdAnnee, @IdSession)",
                    new MySqlParameter("@Sujet", entity.SujetMemoire),
                    new MySqlParameter("@IdAnnee", entity.IdAnneeAcademique),
                    new MySqlParameter("@IdSession", entity.IdSession));

                entity.IdMemoire = Convert.ToInt32(ExecuteScalar("SELECT LAST_INSERT_ID()"));
                return ServiceResult<Memoire>.Success(entity, "Mémoire ajouté avec succès.");
            }
            catch (Exception ex)
            {
                return ServiceResult<Memoire>.Failure($"Erreur lors de l'ajout : {ex.Message}");
            }
        }

        /// <summary>
        /// Met à jour un mémoire
        /// </summary>
        public ServiceResult<Memoire> Update(Memoire entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any())
                return ServiceResult<Memoire>.Failure(erreurs);

            try
            {
                ExecuteNonQuery(@"
                    UPDATE memoires
                    SET SujetMemoire = @Sujet, IdAnneeAcademique = @IdAnnee, IdSession = @IdSession
                    WHERE IdMemoire = @Id",
                    new MySqlParameter("@Sujet", entity.SujetMemoire),
                    new MySqlParameter("@IdAnnee", entity.IdAnneeAcademique),
                    new MySqlParameter("@IdSession", entity.IdSession),
                    new MySqlParameter("@Id", entity.IdMemoire));

                return ServiceResult<Memoire>.Success(entity, "Mémoire modifié avec succès.");
            }
            catch (Exception ex)
            {
                return ServiceResult<Memoire>.Failure($"Erreur lors de la modification : {ex.Message}");
            }
        }

        /// <summary>
        /// Supprime un mémoire
        /// </summary>
        public ServiceResult<bool> Delete(int id)
        {
            try
            {
                ExecuteNonQuery("DELETE FROM memoires WHERE IdMemoire = @Id",
                    new MySqlParameter("@Id", id));
                return ServiceResult<bool>.Success(true, "Mémoire supprimé avec succès.");
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Erreur lors de la suppression : {ex.Message}");
            }
        }

        /// <summary>
        /// Compte le nombre de mémoires par année
        /// </summary>
        public int CountByAnnee(int idAnneeAcademique)
        {
            return Convert.ToInt32(ExecuteScalar(
                "SELECT COUNT(*) FROM memoires WHERE IdAnneeAcademique = @Id",
                new MySqlParameter("@Id", idAnneeAcademique)));
        }

        /// <summary>
        /// Mappe une ligne de données vers un objet Memoire
        /// </summary>
        private Memoire MapMemoire(System.Data.DataRow row)
        {
            var memoire = new Memoire
            {
                IdMemoire = Convert.ToInt32(row["IdMemoire"]),
                SujetMemoire = row["SujetMemoire"]?.ToString(),
                IdAnneeAcademique = row["IdAnneeAcademique"] != DBNull.Value ? Convert.ToInt32(row["IdAnneeAcademique"]) : null,
                IdSession = row["IdSession"] != DBNull.Value ? Convert.ToInt32(row["IdSession"]) : null
            };

            // Charger l'année académique si présente
            if (memoire.IdAnneeAcademique.HasValue && row.Table.Columns.Contains("LibelleAnneeAcademique"))
            {
                memoire.AnneeAcademique = new AnneeAcademique
                {
                    IdAnneeAcademique = memoire.IdAnneeAcademique.Value,
                    LibelleAnneeAcademique = row["LibelleAnneeAcademique"]?.ToString(),
                    AnneeAcademiqueVal = row["AnneeAcademiqueVal"] != DBNull.Value ? Convert.ToInt32(row["AnneeAcademiqueVal"]) : 0
                };
            }

            // Charger la session si présente
            if (memoire.IdSession.HasValue && row.Table.Columns.Contains("LibelleSession"))
            {
                memoire.Session = new Session
                {
                    IdSession = memoire.IdSession.Value,
                    LibelleSession = row["LibelleSession"]?.ToString(),
                    IdAnneeAcademique = memoire.IdAnneeAcademique
                };
            }

            return memoire;
        }
    }
}
