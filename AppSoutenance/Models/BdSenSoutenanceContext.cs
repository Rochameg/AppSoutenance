using MySql.Data.EntityFramework; // Pour la configuration MySQL
using System;
using System.Collections.Generic;
using System.Data.Entity; // Pour DbContext et DbSet
using System.Text;


namespace AppSoutenance.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdSenSoutenanceContext : DbContext
    {

        public BdSenSoutenanceContext() : base("connBdSenSoutenance") { }

        public DbSet<AnneeAcademique> anneeAcademiques { get; set; }

        public DbSet<Session> sessions { get; set; }

        public DbSet<Memoire> memoires { get; set; }

        public DbSet<Soutenance> soutenances { get; set; }

        public DbSet<Utilisateur> utilisateurs { get; set; }

        public DbSet<Admin> admins { get; set; }

        public DbSet<ChefDepartement> ChefDepartements { get; set; }

        public DbSet<Candidat> candidats { get; set; }

        public DbSet<Professeur> professeurs { get; set; }

        public DbSet<Departement> departements { get; set; }





    }
}
