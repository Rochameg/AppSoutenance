namespace AppSoutenance.Migrations
{
    using MySql.Data.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<AppSoutenance.Models.BdSenSoutenanceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            AutomaticMigrationDataLossAllowed = false;

            // On force Entity Framework à utiliser le générateur de code SQL pour MySQL
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
        }

        
    }
}
