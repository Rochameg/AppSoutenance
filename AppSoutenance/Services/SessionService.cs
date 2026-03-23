using AppSoutenance.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppSoutenance.Services
{
    /// <summary>
    /// Service pour la gestion des sessions (ADO.NET)
    /// </summary>
    public class SessionService : BaseServiceADO
    {
        /// <summary>
        /// Récupère toutes les sessions avec l'année académique
        /// </summary>
        public List<Session> GetAll()
        {
            var liste = new List<Session>();
            var dt = ExecuteQuery(@"
                SELECT s.*, a.LibelleAnneeAcademique, a.AnneeAcademiqueVal
                FROM sessions s
                LEFT JOIN anneeAcademiques a ON s.IdAnneeAcademique = a.IdAnneeAcademique
                ORDER BY a.AnneeAcademiqueVal DESC, s.LibelleSession");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                var session = new Session
                {
                    IdSession = Convert.ToInt32(row["IdSession"]),
                    LibelleSession = row["LibelleSession"]?.ToString(),
                    IdAnneeAcademique = row["IdAnneeAcademique"] != DBNull.Value ? Convert.ToInt32(row["IdAnneeAcademique"]) : null
                };
                if (session.IdAnneeAcademique.HasValue)
                {
                    session.AnneeAcademique = new AnneeAcademique
                    {
                        IdAnneeAcademique = session.IdAnneeAcademique.Value,
                        LibelleAnneeAcademique = row["LibelleAnneeAcademique"]?.ToString(),
                        AnneeAcademiqueVal = Convert.ToInt32(row["AnneeAcademiqueVal"])
                    };
                }
                liste.Add(session);
            }
            return liste;
        }

        public Session GetById(int id)
        {
            var dt = ExecuteQuery(@"
                SELECT s.*, a.LibelleAnneeAcademique, a.AnneeAcademiqueVal
                FROM sessions s
                LEFT JOIN anneeAcademiques a ON s.IdAnneeAcademique = a.IdAnneeAcademique
                WHERE s.IdSession = @Id", new MySqlParameter("@Id", id));

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                var session = new Session
                {
                    IdSession = Convert.ToInt32(row["IdSession"]),
                    LibelleSession = row["LibelleSession"]?.ToString(),
                    IdAnneeAcademique = row["IdAnneeAcademique"] != DBNull.Value ? Convert.ToInt32(row["IdAnneeAcademique"]) : null
                };
                return session;
            }
            return null;
        }

        public List<ListItem> GetListItems(int? idAnneeAcademique = null)
        {
            var liste = new List<ListItem> { new ListItem { Value = null, Text = "-- Sélectionner --" } };

            string query = @"SELECT s.*, a.LibelleAnneeAcademique FROM sessions s
                             LEFT JOIN anneeAcademiques a ON s.IdAnneeAcademique = a.IdAnneeAcademique";
            if (idAnneeAcademique.HasValue)
                query += " WHERE s.IdAnneeAcademique = @IdAnnee";
            query += " ORDER BY s.LibelleSession";

            var parameters = idAnneeAcademique.HasValue
                ? new[] { new MySqlParameter("@IdAnnee", idAnneeAcademique.Value) }
                : Array.Empty<MySqlParameter>();

            var dt = ExecuteQuery(query, parameters);
            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(new ListItem
                {
                    Value = row["IdSession"].ToString(),
                    Text = $"{row["LibelleSession"]} ({row["LibelleAnneeAcademique"]})"
                });
            }
            return liste;
        }

        public List<string> Valider(Session session)
        {
            var erreurs = new List<string>();
            if (string.IsNullOrWhiteSpace(session.LibelleSession))
                erreurs.Add("Le libellé de la session est requis.");
            if (session.LibelleSession?.Length > 50)
                erreurs.Add("Le libellé ne doit pas dépasser 50 caractères.");
            if (!session.IdAnneeAcademique.HasValue)
                erreurs.Add("L'année académique est requise.");

            var count = Convert.ToInt32(ExecuteScalar(
                "SELECT COUNT(*) FROM sessions WHERE LibelleSession = @Libelle AND IdAnneeAcademique = @IdAnnee AND IdSession != @Id",
                new MySqlParameter("@Libelle", session.LibelleSession ?? ""),
                new MySqlParameter("@IdAnnee", session.IdAnneeAcademique ?? 0),
                new MySqlParameter("@Id", session.IdSession)));
            if (count > 0)
                erreurs.Add("Cette session existe déjà pour cette année académique.");

            return erreurs;
        }

        public ServiceResult<Session> Add(Session entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any()) return ServiceResult<Session>.Failure(erreurs);

            try
            {
                ExecuteNonQuery("INSERT INTO sessions (LibelleSession, IdAnneeAcademique) VALUES (@Libelle, @IdAnnee)",
                    new MySqlParameter("@Libelle", entity.LibelleSession),
                    new MySqlParameter("@IdAnnee", entity.IdAnneeAcademique));
                entity.IdSession = Convert.ToInt32(ExecuteScalar("SELECT LAST_INSERT_ID()"));
                return ServiceResult<Session>.Success(entity, "Session ajoutée avec succès.");
            }
            catch (Exception ex) { return ServiceResult<Session>.Failure($"Erreur : {ex.Message}"); }
        }

        public ServiceResult<Session> Update(Session entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any()) return ServiceResult<Session>.Failure(erreurs);

            try
            {
                ExecuteNonQuery("UPDATE sessions SET LibelleSession = @Libelle, IdAnneeAcademique = @IdAnnee WHERE IdSession = @Id",
                    new MySqlParameter("@Libelle", entity.LibelleSession),
                    new MySqlParameter("@IdAnnee", entity.IdAnneeAcademique),
                    new MySqlParameter("@Id", entity.IdSession));
                return ServiceResult<Session>.Success(entity, "Session modifiée avec succès.");
            }
            catch (Exception ex) { return ServiceResult<Session>.Failure($"Erreur : {ex.Message}"); }
        }

        public ServiceResult<bool> Delete(int id)
        {
            try
            {
                ExecuteNonQuery("DELETE FROM sessions WHERE IdSession = @Id", new MySqlParameter("@Id", id));
                return ServiceResult<bool>.Success(true, "Session supprimée avec succès.");
            }
            catch (Exception ex) { return ServiceResult<bool>.Failure($"Erreur : {ex.Message}"); }
        }

        /// <summary>
        /// Recherche des sessions par libellé et/ou année académique
        /// </summary>
        public List<Session> Rechercher(string libelle = null, string anneeAcademique = null)
        {
            var liste = new List<Session>();
            var parameters = new List<MySqlParameter>();

            string query = @"
                SELECT s.*, a.LibelleAnneeAcademique, a.AnneeAcademiqueVal
                FROM sessions s
                LEFT JOIN anneeAcademiques a ON s.IdAnneeAcademique = a.IdAnneeAcademique
                WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(libelle))
            {
                query += " AND s.LibelleSession LIKE @Libelle";
                parameters.Add(new MySqlParameter("@Libelle", $"%{libelle}%"));
            }

            if (!string.IsNullOrWhiteSpace(anneeAcademique))
            {
                query += " AND a.LibelleAnneeAcademique LIKE @AnneeAcademique";
                parameters.Add(new MySqlParameter("@AnneeAcademique", $"%{anneeAcademique}%"));
            }

            query += " ORDER BY a.AnneeAcademiqueVal DESC, s.LibelleSession";

            var dt = ExecuteQuery(query, parameters.ToArray());
            foreach (System.Data.DataRow row in dt.Rows)
            {
                var session = new Session
                {
                    IdSession = Convert.ToInt32(row["IdSession"]),
                    LibelleSession = row["LibelleSession"]?.ToString(),
                    IdAnneeAcademique = row["IdAnneeAcademique"] != DBNull.Value ? Convert.ToInt32(row["IdAnneeAcademique"]) : null
                };
                if (session.IdAnneeAcademique.HasValue)
                {
                    session.AnneeAcademique = new AnneeAcademique
                    {
                        IdAnneeAcademique = session.IdAnneeAcademique.Value,
                        LibelleAnneeAcademique = row["LibelleAnneeAcademique"]?.ToString(),
                        AnneeAcademiqueVal = Convert.ToInt32(row["AnneeAcademiqueVal"])
                    };
                }
                liste.Add(session);
            }
            return liste;
        }
    }
}
