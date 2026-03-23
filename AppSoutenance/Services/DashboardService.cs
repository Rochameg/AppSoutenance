using AppSoutenance.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AppSoutenance.Services
{
    /// <summary>
    /// Service pour les statistiques du tableau de bord (ADO.NET)
    /// </summary>
    public class DashboardService : BaseServiceADO
    {
        /// <summary>
        /// Récupère les statistiques générales
        /// </summary>
        public DashboardStats GetStatistiques()
        {
            var stats = new DashboardStats
            {
                NombreAnneeAcademiques = Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM anneeAcademiques")),
                NombreSessions = Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM sessions")),
                NombreDepartements = Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM departements")),
                NombreProfesseurs = Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM utilisateurs WHERE Discriminator = 'Professeur'")),
                NombreCandidats = Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM utilisateurs WHERE Discriminator = 'Candidat'")),
                NombreMemoires = Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM memoires")),
                NombreSoutenances = Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM soutenances")),
                NombreSoutenancesPlanifiees = Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM soutenances WHERE DateSoutenance > NOW()")),
                NombreSoutenancesTerminees = Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM soutenances WHERE DateSoutenance <= NOW()"))
            };

            // Année académique actuelle
            var dt = ExecuteQuery("SELECT * FROM anneeAcademiques ORDER BY AnneeAcademiqueVal DESC LIMIT 1");
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                var idAnnee = Convert.ToInt32(row["IdAnneeAcademique"]);
                stats.AnneeActuelle = row["LibelleAnneeAcademique"]?.ToString();
                stats.NombreMemoiresAnneeActuelle = Convert.ToInt32(ExecuteScalar(
                    "SELECT COUNT(*) FROM memoires WHERE IdAnneeAcademique = @Id",
                    new MySqlParameter("@Id", idAnnee)));
                stats.NombreSoutenancesAnneeActuelle = Convert.ToInt32(ExecuteScalar(
                    "SELECT COUNT(*) FROM soutenances s JOIN memoires m ON s.IdMemoire = m.IdMemoire WHERE m.IdAnneeAcademique = @Id",
                    new MySqlParameter("@Id", idAnnee)));
            }

            return stats;
        }

        /// <summary>
        /// Récupère les prochaines soutenances
        /// </summary>
        public List<SoutenanceResume> GetProchainesSoutenances(int nombre = 5)
        {
            var liste = new List<SoutenanceResume>();
            var dt = ExecuteQuery($@"
                SELECT s.IdSoutenance, m.SujetMemoire, s.DateSoutenance, s.LieuSoutenance
                FROM soutenances s
                LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire
                WHERE s.DateSoutenance > NOW()
                ORDER BY s.DateSoutenance
                LIMIT {nombre}");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(new SoutenanceResume
                {
                    IdSoutenance = Convert.ToInt32(row["IdSoutenance"]),
                    SujetMemoire = row["SujetMemoire"]?.ToString(),
                    DateSoutenance = Convert.ToDateTime(row["DateSoutenance"]),
                    LieuSoutenance = row["LieuSoutenance"]?.ToString()
                });
            }
            return liste;
        }

        /// <summary>
        /// Récupère les dernières soutenances
        /// </summary>
        public List<SoutenanceResume> GetDernieresSoutenances(int nombre = 5)
        {
            var liste = new List<SoutenanceResume>();
            var dt = ExecuteQuery($@"
                SELECT s.IdSoutenance, m.SujetMemoire, s.DateSoutenance, s.LieuSoutenance, s.ResultatSoutenance, s.MentionSoutenance
                FROM soutenances s
                LEFT JOIN memoires m ON s.IdMemoire = m.IdMemoire
                WHERE s.DateSoutenance <= NOW()
                ORDER BY s.DateSoutenance DESC
                LIMIT {nombre}");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(new SoutenanceResume
                {
                    IdSoutenance = Convert.ToInt32(row["IdSoutenance"]),
                    SujetMemoire = row["SujetMemoire"]?.ToString(),
                    DateSoutenance = Convert.ToDateTime(row["DateSoutenance"]),
                    LieuSoutenance = row["LieuSoutenance"]?.ToString(),
                    Resultat = row["ResultatSoutenance"]?.ToString(),
                    Mention = row["MentionSoutenance"]?.ToString()
                });
            }
            return liste;
        }

        /// <summary>
        /// Récupère les statistiques par mention
        /// </summary>
        public Dictionary<string, int> GetStatistiquesMentions()
        {
            var dict = new Dictionary<string, int>();
            var dt = ExecuteQuery(@"
                SELECT MentionSoutenance, COUNT(*) as Total
                FROM soutenances
                WHERE MentionSoutenance IS NOT NULL AND MentionSoutenance != ''
                GROUP BY MentionSoutenance");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                var mention = row["MentionSoutenance"]?.ToString();
                if (!string.IsNullOrEmpty(mention))
                    dict[mention] = Convert.ToInt32(row["Total"]);
            }
            return dict;
        }

        /// <summary>
        /// Récupère les statistiques par année académique
        /// </summary>
        public List<StatistiqueAnnee> GetStatistiquesParAnnee()
        {
            var liste = new List<StatistiqueAnnee>();
            var dt = ExecuteQuery(@"
                SELECT a.LibelleAnneeAcademique,
                       (SELECT COUNT(*) FROM memoires m WHERE m.IdAnneeAcademique = a.IdAnneeAcademique) as NombreMemoires,
                       (SELECT COUNT(*) FROM soutenances s JOIN memoires m2 ON s.IdMemoire = m2.IdMemoire WHERE m2.IdAnneeAcademique = a.IdAnneeAcademique) as NombreSoutenances
                FROM anneeAcademiques a
                ORDER BY a.AnneeAcademiqueVal DESC
                LIMIT 5");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(new StatistiqueAnnee
                {
                    Annee = row["LibelleAnneeAcademique"]?.ToString(),
                    NombreMemoires = Convert.ToInt32(row["NombreMemoires"]),
                    NombreSoutenances = Convert.ToInt32(row["NombreSoutenances"])
                });
            }
            return liste;
        }
    }

    /// <summary>
    /// Statistiques du tableau de bord
    /// </summary>
    public class DashboardStats
    {
        public int NombreAnneeAcademiques { get; set; }
        public int NombreSessions { get; set; }
        public int NombreDepartements { get; set; }
        public int NombreProfesseurs { get; set; }
        public int NombreCandidats { get; set; }
        public int NombreMemoires { get; set; }
        public int NombreSoutenances { get; set; }
        public int NombreSoutenancesPlanifiees { get; set; }
        public int NombreSoutenancesTerminees { get; set; }
        public string? AnneeActuelle { get; set; }
        public int NombreMemoiresAnneeActuelle { get; set; }
        public int NombreSoutenancesAnneeActuelle { get; set; }
    }

    /// <summary>
    /// Résumé d'une soutenance
    /// </summary>
    public class SoutenanceResume
    {
        public int IdSoutenance { get; set; }
        public string? SujetMemoire { get; set; }
        public DateTime DateSoutenance { get; set; }
        public string? LieuSoutenance { get; set; }
        public string? Resultat { get; set; }
        public string? Mention { get; set; }
    }

    /// <summary>
    /// Statistique par année
    /// </summary>
    public class StatistiqueAnnee
    {
        public string? Annee { get; set; }
        public int NombreMemoires { get; set; }
        public int NombreSoutenances { get; set; }
    }
}
