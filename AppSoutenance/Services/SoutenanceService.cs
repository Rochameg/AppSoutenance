using AppSoutenance.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppSoutenance.Services
{
    /// <summary>
    /// Service pour la gestion des soutenances (ADO.NET)
    /// </summary>
    public class SoutenanceService : BaseServiceADO
    {
        /// <summary>
        /// Récupère toutes les soutenances avec les relations
        /// </summary>
        public List<Soutenance> GetAll()
        {
            var liste = new List<Soutenance>();
            var dt = ExecuteQuery(@"
                SELECT s.*,
                       m.SujetMemoire, m.IdAnneeAcademique as MemoireIdAnnee, m.IdSession as MemoireIdSession,
                       a.LibelleAnneeAcademique, a.AnneeAcademiqueVal,
                       ses.LibelleSession
                FROM soutenances s
                LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire
                LEFT JOIN anneeAcademiques a ON m.IdAnneeAcademique = a.IdAnneeAcademique
                LEFT JOIN sessions ses ON m.IdSession = ses.IdSession
                ORDER BY s.DateSoutenance DESC");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(MapSoutenance(row));
            }
            return liste;
        }

        /// <summary>
        /// Récupère une soutenance par ID avec les relations
        /// </summary>
        public Soutenance GetById(int id)
        {
            var dt = ExecuteQuery(@"
                SELECT s.*,
                       m.SujetMemoire, m.IdAnneeAcademique as MemoireIdAnnee, m.IdSession as MemoireIdSession,
                       a.LibelleAnneeAcademique, a.AnneeAcademiqueVal,
                       ses.LibelleSession
                FROM soutenances s
                LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire
                LEFT JOIN anneeAcademiques a ON m.IdAnneeAcademique = a.IdAnneeAcademique
                LEFT JOIN sessions ses ON m.IdSession = ses.IdSession
                WHERE s.IdSoutenance = @Id", new MySqlParameter("@Id", id));

            if (dt.Rows.Count > 0)
            {
                return MapSoutenance(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Récupère la soutenance d'un mémoire
        /// </summary>
        public Soutenance GetByMemoire(int idMemoire)
        {
            var dt = ExecuteQuery(@"
                SELECT s.*, m.SujetMemoire
                FROM soutenances s
                LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire
                WHERE s.IdMemoire = @IdMemoire", new MySqlParameter("@IdMemoire", idMemoire));

            if (dt.Rows.Count > 0)
            {
                return MapSoutenance(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Récupère les soutenances planifiées (futures)
        /// </summary>
        public List<Soutenance> GetSoutenancesPlanifiees()
        {
            var liste = new List<Soutenance>();
            var dt = ExecuteQuery(@"
                SELECT s.*,
                       m.SujetMemoire, m.IdAnneeAcademique as MemoireIdAnnee,
                       a.LibelleAnneeAcademique, a.AnneeAcademiqueVal
                FROM soutenances s
                LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire
                LEFT JOIN anneeAcademiques a ON m.IdAnneeAcademique = a.IdAnneeAcademique
                WHERE s.DateSoutenance > NOW()
                ORDER BY s.DateSoutenance");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(MapSoutenance(row));
            }
            return liste;
        }

        /// <summary>
        /// Récupère les soutenances passées
        /// </summary>
        public List<Soutenance> GetSoutenancesPassees()
        {
            var liste = new List<Soutenance>();
            var dt = ExecuteQuery(@"
                SELECT s.*,
                       m.SujetMemoire, m.IdAnneeAcademique as MemoireIdAnnee,
                       a.LibelleAnneeAcademique, a.AnneeAcademiqueVal
                FROM soutenances s
                LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire
                LEFT JOIN anneeAcademiques a ON m.IdAnneeAcademique = a.IdAnneeAcademique
                WHERE s.DateSoutenance <= NOW()
                ORDER BY s.DateSoutenance DESC");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(MapSoutenance(row));
            }
            return liste;
        }

        /// <summary>
        /// Recherche des soutenances
        /// </summary>
        public List<Soutenance> Rechercher(string sujet = null, DateTime? dateDebut = null,
            DateTime? dateFin = null, string resultat = null)
        {
            var liste = new List<Soutenance>();
            var parameters = new List<MySqlParameter>();

            string query = @"
                SELECT s.*,
                       m.SujetMemoire, m.IdAnneeAcademique as MemoireIdAnnee, m.IdSession as MemoireIdSession,
                       a.LibelleAnneeAcademique, a.AnneeAcademiqueVal,
                       ses.LibelleSession
                FROM soutenances s
                LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire
                LEFT JOIN anneeAcademiques a ON m.IdAnneeAcademique = a.IdAnneeAcademique
                LEFT JOIN sessions ses ON m.IdSession = ses.IdSession
                WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(sujet))
            {
                query += " AND m.SujetMemoire LIKE @Sujet";
                parameters.Add(new MySqlParameter("@Sujet", $"%{sujet}%"));
            }

            if (dateDebut.HasValue)
            {
                query += " AND s.DateSoutenance >= @DateDebut";
                parameters.Add(new MySqlParameter("@DateDebut", dateDebut.Value));
            }

            if (dateFin.HasValue)
            {
                query += " AND s.DateSoutenance <= @DateFin";
                parameters.Add(new MySqlParameter("@DateFin", dateFin.Value));
            }

            if (!string.IsNullOrWhiteSpace(resultat))
            {
                query += " AND s.ResultatSoutenance = @Resultat";
                parameters.Add(new MySqlParameter("@Resultat", resultat));
            }

            query += " ORDER BY s.DateSoutenance DESC";

            var dt = ExecuteQuery(query, parameters.ToArray());
            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(MapSoutenance(row));
            }
            return liste;
        }

        /// <summary>
        /// Récupère les soutenances d'une période
        /// </summary>
        public List<Soutenance> GetByPeriode(DateTime dateDebut, DateTime dateFin)
        {
            var liste = new List<Soutenance>();
            var dt = ExecuteQuery(@"
                SELECT s.*, m.SujetMemoire
                FROM soutenances s
                LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire
                WHERE s.DateSoutenance >= @DateDebut AND s.DateSoutenance <= @DateFin
                ORDER BY s.DateSoutenance",
                new MySqlParameter("@DateDebut", dateDebut),
                new MySqlParameter("@DateFin", dateFin));

            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(MapSoutenance(row));
            }
            return liste;
        }

        /// <summary>
        /// Valide une soutenance avant sauvegarde
        /// </summary>
        public List<string> Valider(Soutenance soutenance)
        {
            var erreurs = new List<string>();

            if (!soutenance.IdMemoire.HasValue)
                erreurs.Add("Le mémoire est requis.");

            if (soutenance.DateSoutenance == default(DateTime))
                erreurs.Add("La date de soutenance est requise.");

            if (string.IsNullOrWhiteSpace(soutenance.LieuSoutenance))
                erreurs.Add("Le lieu de soutenance est requis.");

            if (soutenance.LieuSoutenance?.Length > 2000)
                erreurs.Add("Le lieu ne doit pas dépasser 2000 caractères.");

            // Vérifier qu'il n'y a pas déjà une soutenance pour ce mémoire
            var count = Convert.ToInt32(ExecuteScalar(
                "SELECT COUNT(*) FROM soutenances WHERE IdMemoire = @IdMemoire AND IdSoutenance != @Id",
                new MySqlParameter("@IdMemoire", soutenance.IdMemoire ?? 0),
                new MySqlParameter("@Id", soutenance.IdSoutenance)));

            if (count > 0)
                erreurs.Add("Une soutenance existe déjà pour ce mémoire.");

            return erreurs;
        }

        /// <summary>
        /// Ajoute une soutenance
        /// </summary>
        public ServiceResult<Soutenance> Add(Soutenance entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any())
                return ServiceResult<Soutenance>.Failure(erreurs);

            if (entity.DateSoutenance == default(DateTime))
                entity.DateSoutenance = DateTime.Now;

            try
            {
                ExecuteNonQuery(@"
                    INSERT INTO soutenances (IdMemoire, DateSoutenance, LieuSoutenance, ResultatSoutenance, MentionSoutenance)
                    VALUES (@IdMemoire, @Date, @Lieu, @Resultat, @Mention)",
                    new MySqlParameter("@IdMemoire", entity.IdMemoire),
                    new MySqlParameter("@Date", entity.DateSoutenance),
                    new MySqlParameter("@Lieu", entity.LieuSoutenance),
                    new MySqlParameter("@Resultat", (object)entity.ResultatSoutenance ?? DBNull.Value),
                    new MySqlParameter("@Mention", (object)entity.MentionSoutenance ?? DBNull.Value));

                entity.IdSoutenance = Convert.ToInt32(ExecuteScalar("SELECT LAST_INSERT_ID()"));
                return ServiceResult<Soutenance>.Success(entity, "Soutenance ajoutée avec succès.");
            }
            catch (Exception ex)
            {
                return ServiceResult<Soutenance>.Failure($"Erreur lors de l'ajout : {ex.Message}");
            }
        }

        /// <summary>
        /// Met à jour une soutenance
        /// </summary>
        public ServiceResult<Soutenance> Update(Soutenance entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any())
                return ServiceResult<Soutenance>.Failure(erreurs);

            try
            {
                ExecuteNonQuery(@"
                    UPDATE soutenances
                    SET IdMemoire = @IdMemoire, DateSoutenance = @Date, LieuSoutenance = @Lieu,
                        ResultatSoutenance = @Resultat, MentionSoutenance = @Mention
                    WHERE IdSoutenance = @Id",
                    new MySqlParameter("@IdMemoire", entity.IdMemoire),
                    new MySqlParameter("@Date", entity.DateSoutenance),
                    new MySqlParameter("@Lieu", entity.LieuSoutenance),
                    new MySqlParameter("@Resultat", (object)entity.ResultatSoutenance ?? DBNull.Value),
                    new MySqlParameter("@Mention", (object)entity.MentionSoutenance ?? DBNull.Value),
                    new MySqlParameter("@Id", entity.IdSoutenance));

                return ServiceResult<Soutenance>.Success(entity, "Soutenance modifiée avec succès.");
            }
            catch (Exception ex)
            {
                return ServiceResult<Soutenance>.Failure($"Erreur lors de la modification : {ex.Message}");
            }
        }

        /// <summary>
        /// Supprime une soutenance
        /// </summary>
        public ServiceResult<bool> Delete(int id)
        {
            try
            {
                ExecuteNonQuery("DELETE FROM soutenances WHERE IdSoutenance = @Id",
                    new MySqlParameter("@Id", id));
                return ServiceResult<bool>.Success(true, "Soutenance supprimée avec succès.");
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Failure($"Erreur lors de la suppression : {ex.Message}");
            }
        }

        /// <summary>
        /// Statistiques des soutenances
        /// </summary>
        public SoutenanceStats GetStatistiques(int? idAnneeAcademique = null)
        {
            var stats = new SoutenanceStats();
            var parameters = new List<MySqlParameter>();

            string whereClause = "";
            if (idAnneeAcademique.HasValue)
            {
                whereClause = " WHERE m.IdAnneeAcademique = @IdAnnee";
                parameters.Add(new MySqlParameter("@IdAnnee", idAnneeAcademique.Value));
            }

            // Total
            stats.Total = Convert.ToInt32(ExecuteScalar(
                $"SELECT COUNT(*) FROM soutenances s LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire {whereClause}",
                parameters.ToArray()));

            // Planifiées
            var paramsPlanifiees = new List<MySqlParameter>(parameters.Select(p => new MySqlParameter(p.ParameterName, p.Value)));
            stats.Planifiees = Convert.ToInt32(ExecuteScalar(
                $"SELECT COUNT(*) FROM soutenances s LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire {(string.IsNullOrEmpty(whereClause) ? "WHERE" : whereClause + " AND")} s.DateSoutenance > NOW()",
                paramsPlanifiees.ToArray()));

            // Terminées
            var paramsTerminees = new List<MySqlParameter>(parameters.Select(p => new MySqlParameter(p.ParameterName, p.Value)));
            stats.Terminees = Convert.ToInt32(ExecuteScalar(
                $"SELECT COUNT(*) FROM soutenances s LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire {(string.IsNullOrEmpty(whereClause) ? "WHERE" : whereClause + " AND")} s.DateSoutenance <= NOW() AND s.ResultatSoutenance IS NOT NULL AND s.ResultatSoutenance != ''",
                paramsTerminees.ToArray()));

            // En attente
            var paramsAttente = new List<MySqlParameter>(parameters.Select(p => new MySqlParameter(p.ParameterName, p.Value)));
            stats.EnAttente = Convert.ToInt32(ExecuteScalar(
                $"SELECT COUNT(*) FROM soutenances s LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire {(string.IsNullOrEmpty(whereClause) ? "WHERE" : whereClause + " AND")} s.DateSoutenance <= NOW() AND (s.ResultatSoutenance IS NULL OR s.ResultatSoutenance = '')",
                paramsAttente.ToArray()));

            // Réussies
            var paramsReussies = new List<MySqlParameter>(parameters.Select(p => new MySqlParameter(p.ParameterName, p.Value)));
            stats.Reussies = Convert.ToInt32(ExecuteScalar(
                $"SELECT COUNT(*) FROM soutenances s LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire {(string.IsNullOrEmpty(whereClause) ? "WHERE" : whereClause + " AND")} LOWER(s.ResultatSoutenance) = 'admis'",
                paramsReussies.ToArray()));

            // Échouées
            var paramsEchouees = new List<MySqlParameter>(parameters.Select(p => new MySqlParameter(p.ParameterName, p.Value)));
            stats.Echouees = Convert.ToInt32(ExecuteScalar(
                $"SELECT COUNT(*) FROM soutenances s LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire {(string.IsNullOrEmpty(whereClause) ? "WHERE" : whereClause + " AND")} LOWER(s.ResultatSoutenance) = 'ajourné'",
                paramsEchouees.ToArray()));

            return stats;
        }

        /// <summary>
        /// Mappe une ligne de données vers un objet Soutenance
        /// </summary>
        private Soutenance MapSoutenance(System.Data.DataRow row)
        {
            var soutenance = new Soutenance
            {
                IdSoutenance = Convert.ToInt32(row["IdSoutenance"]),
                IdMemoire = row["IdMemoire"] != DBNull.Value ? Convert.ToInt32(row["IdMemoire"]) : null,
                DateSoutenance = Convert.ToDateTime(row["DateSoutenance"]),
                LieuSoutenance = row["LieuSoutenance"]?.ToString(),
                ResultatSoutenance = row["ResultatSoutenance"]?.ToString(),
                MentionSoutenance = row["MentionSoutenance"]?.ToString()
            };

            // Charger le mémoire si présent
            if (soutenance.IdMemoire.HasValue && row.Table.Columns.Contains("SujetMemoire"))
            {
                soutenance.Memoire = new Memoire
                {
                    IdMemoire = soutenance.IdMemoire.Value,
                    SujetMemoire = row["SujetMemoire"]?.ToString()
                };

                // Charger l'année académique du mémoire si présente
                if (row.Table.Columns.Contains("MemoireIdAnnee") && row["MemoireIdAnnee"] != DBNull.Value)
                {
                    soutenance.Memoire.IdAnneeAcademique = Convert.ToInt32(row["MemoireIdAnnee"]);

                    if (row.Table.Columns.Contains("LibelleAnneeAcademique"))
                    {
                        soutenance.Memoire.AnneeAcademique = new AnneeAcademique
                        {
                            IdAnneeAcademique = soutenance.Memoire.IdAnneeAcademique.Value,
                            LibelleAnneeAcademique = row["LibelleAnneeAcademique"]?.ToString(),
                            AnneeAcademiqueVal = row["AnneeAcademiqueVal"] != DBNull.Value ? Convert.ToInt32(row["AnneeAcademiqueVal"]) : 0
                        };
                    }
                }

                // Charger la session du mémoire si présente
                if (row.Table.Columns.Contains("MemoireIdSession") && row["MemoireIdSession"] != DBNull.Value)
                {
                    soutenance.Memoire.IdSession = Convert.ToInt32(row["MemoireIdSession"]);

                    if (row.Table.Columns.Contains("LibelleSession"))
                    {
                        soutenance.Memoire.Session = new Session
                        {
                            IdSession = soutenance.Memoire.IdSession.Value,
                            LibelleSession = row["LibelleSession"]?.ToString()
                        };
                    }
                }
            }

            return soutenance;
        }
    }

    /// <summary>
    /// Classe de statistiques des soutenances
    /// </summary>
    public class SoutenanceStats
    {
        public int Total { get; set; }
        public int Planifiees { get; set; }
        public int Terminees { get; set; }
        public int EnAttente { get; set; }
        public int Reussies { get; set; }
        public int Echouees { get; set; }
    }
}
