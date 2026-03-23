using AppSoutenance.Models;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AppSoutenance.Services
{
    /// <summary>
    /// Service d'authentification et de gestion des utilisateurs
    /// </summary>
    public class AuthentificationService
    {
        private static Utilisateur _currentUser;
        private readonly string _connectionString;

        public AuthentificationService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connBdSenSoutenance"]?.ConnectionString
                ?? "server=localhost;port=3306;database=soutenance_db;uid=root;password=passer";
        }

        /// <summary>
        /// Utilisateur actuellement connecté
        /// </summary>
        public static Utilisateur CurrentUser
        {
            get => _currentUser;
            private set => _currentUser = value;
        }

        /// <summary>
        /// Rôle de l'utilisateur connecté
        /// </summary>
        public static string CurrentUserRole { get; private set; }

        /// <summary>
        /// Authentifie un utilisateur avec email et mot de passe (utilise ADO.NET directement)
        /// </summary>
        public ServiceResult<Utilisateur> Authentifier(string email, string motDePasse)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return ServiceResult<Utilisateur>.Failure("L'email est requis.");
            }

            if (string.IsNullOrWhiteSpace(motDePasse))
            {
                return ServiceResult<Utilisateur>.Failure("Le mot de passe est requis.");
            }

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"SELECT IdUtilisateur, NomUtilisateur, PrenomUtilisateur, TelUtilisateur,
                                     EmailUtilisateur, MotDeUtilisateur, Discriminator,
                                     MatriculeCandidat, SpecialiteProfesseur, IdDepartement
                                     FROM utilisateurs
                                     WHERE EmailUtilisateur = @Email AND MotDeUtilisateur = @Password";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", motDePasse);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var discriminator = reader["Discriminator"].ToString();
                                Utilisateur user = CreateUserFromReader(reader, discriminator);

                                CurrentUser = user;
                                CurrentUserRole = discriminator;

                                return ServiceResult<Utilisateur>.Success(user, $"Bienvenue {user.PrenomUtilisateur} !");
                            }
                        }
                    }
                }

                return ServiceResult<Utilisateur>.Failure("Email ou mot de passe incorrect.");
            }
            catch (Exception ex)
            {
                return ServiceResult<Utilisateur>.Failure($"Erreur de connexion à la base de données: {ex.Message}");
            }
        }

        private Utilisateur CreateUserFromReader(MySqlDataReader reader, string discriminator)
        {
            Utilisateur user;

            switch (discriminator)
            {
                case "Admin":
                    user = new Admin();
                    break;
                case "Candidat":
                    var candidat = new Candidat();
                    candidat.MatriculeCandidat = reader["MatriculeCandidat"]?.ToString() ?? "";
                    user = candidat;
                    break;
                case "Professeur":
                    var prof = new Professeur();
                    prof.SpecialiteProfesseur = reader["SpecialiteProfesseur"]?.ToString() ?? "";
                    user = prof;
                    break;
                case "ChefDepartement":
                    var chef = new ChefDepartement();
                    if (reader["IdDepartement"] != DBNull.Value)
                        chef.IdDepartement = Convert.ToInt32(reader["IdDepartement"]);
                    user = chef;
                    break;
                default:
                    user = new Utilisateur();
                    break;
            }

            user.IdUtilisateur = Convert.ToInt32(reader["IdUtilisateur"]);
            user.NomUtilisateur = reader["NomUtilisateur"].ToString() ?? "";
            user.PrenomUtilisateur = reader["PrenomUtilisateur"].ToString() ?? "";
            user.TelUtilisateur = reader["TelUtilisateur"].ToString() ?? "";
            user.EmailUtilisateur = reader["EmailUtilisateur"].ToString() ?? "";
            user.MotDeUtilisateur = reader["MotDeUtilisateur"].ToString() ?? "";

            return user;
        }

        /// <summary>
        /// Déconnecte l'utilisateur actuel
        /// </summary>
        public void Deconnecter()
        {
            CurrentUser = null;
            CurrentUserRole = null;
        }

        /// <summary>
        /// Vérifie si un utilisateur est connecté
        /// </summary>
        public static bool EstConnecte()
        {
            return CurrentUser != null;
        }

        /// <summary>
        /// Vérifie si l'utilisateur a un rôle spécifique
        /// </summary>
        public static bool HasRole(string role)
        {
            return CurrentUserRole?.Equals(role, StringComparison.OrdinalIgnoreCase) == true;
        }

        /// <summary>
        /// Vérifie si l'utilisateur a l'un des rôles spécifiés
        /// </summary>
        public static bool HasAnyRole(params string[] roles)
        {
            return roles.Any(r => HasRole(r));
        }

        /// <summary>
        /// Hash un mot de passe (pour usage futur)
        /// </summary>
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        /// <summary>
        /// Vérifie un mot de passe contre son hash
        /// </summary>
        public static bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}
