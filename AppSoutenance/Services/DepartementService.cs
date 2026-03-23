using AppSoutenance.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppSoutenance.Services
{
    /// <summary>
    /// Service pour la gestion des départements (ADO.NET)
    /// </summary>
    public class DepartementService : BaseServiceADO
    {
        public List<Departement> GetAll()
        {
            var liste = new List<Departement>();
            var dt = ExecuteQuery("SELECT * FROM departements ORDER BY LibelleDepartement");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(new Departement
                {
                    IdDepartement = Convert.ToInt32(row["IdDepartement"]),
                    LibelleDepartement = row["LibelleDepartement"]?.ToString() ?? ""
                });
            }
            return liste;
        }

        public Departement GetById(int id)
        {
            var dt = ExecuteQuery("SELECT * FROM departements WHERE IdDepartement = @Id", new MySqlParameter("@Id", id));
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new Departement
                {
                    IdDepartement = Convert.ToInt32(row["IdDepartement"]),
                    LibelleDepartement = row["LibelleDepartement"]?.ToString() ?? ""
                };
            }
            return null;
        }

        public List<Departement> RechercherParLibelle(string libelle)
        {
            if (string.IsNullOrWhiteSpace(libelle)) return GetAll();
            var liste = new List<Departement>();
            var dt = ExecuteQuery("SELECT * FROM departements WHERE LibelleDepartement LIKE @Libelle ORDER BY LibelleDepartement",
                new MySqlParameter("@Libelle", $"%{libelle}%"));
            foreach (System.Data.DataRow row in dt.Rows)
            {
                liste.Add(new Departement
                {
                    IdDepartement = Convert.ToInt32(row["IdDepartement"]),
                    LibelleDepartement = row["LibelleDepartement"]?.ToString() ?? ""
                });
            }
            return liste;
        }

        public List<ListItem> GetListItems()
        {
            var liste = new List<ListItem> { new ListItem { Value = null, Text = "-- Sélectionner --" } };
            foreach (var dept in GetAll())
            {
                liste.Add(new ListItem { Value = dept.IdDepartement.ToString(), Text = dept.LibelleDepartement });
            }
            return liste;
        }

        public List<string> Valider(Departement departement)
        {
            var erreurs = new List<string>();
            if (string.IsNullOrWhiteSpace(departement.LibelleDepartement))
                erreurs.Add("Le libellé du département est requis.");
            if (departement.LibelleDepartement?.Length > 80)
                erreurs.Add("Le libellé ne doit pas dépasser 80 caractères.");

            var count = Convert.ToInt32(ExecuteScalar(
                "SELECT COUNT(*) FROM departements WHERE LibelleDepartement = @Libelle AND IdDepartement != @Id",
                new MySqlParameter("@Libelle", departement.LibelleDepartement ?? ""),
                new MySqlParameter("@Id", departement.IdDepartement)));
            if (count > 0) erreurs.Add("Ce département existe déjà.");
            return erreurs;
        }

        public ServiceResult<Departement> Add(Departement entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any()) return ServiceResult<Departement>.Failure(erreurs);
            try
            {
                ExecuteNonQuery("INSERT INTO departements (LibelleDepartement) VALUES (@Libelle)",
                    new MySqlParameter("@Libelle", entity.LibelleDepartement));
                entity.IdDepartement = Convert.ToInt32(ExecuteScalar("SELECT LAST_INSERT_ID()"));
                return ServiceResult<Departement>.Success(entity, "Département ajouté avec succès.");
            }
            catch (Exception ex) { return ServiceResult<Departement>.Failure($"Erreur : {ex.Message}"); }
        }

        public ServiceResult<Departement> Update(Departement entity)
        {
            var erreurs = Valider(entity);
            if (erreurs.Any()) return ServiceResult<Departement>.Failure(erreurs);
            try
            {
                ExecuteNonQuery("UPDATE departements SET LibelleDepartement = @Libelle WHERE IdDepartement = @Id",
                    new MySqlParameter("@Libelle", entity.LibelleDepartement),
                    new MySqlParameter("@Id", entity.IdDepartement));
                return ServiceResult<Departement>.Success(entity, "Département modifié avec succès.");
            }
            catch (Exception ex) { return ServiceResult<Departement>.Failure($"Erreur : {ex.Message}"); }
        }

        public ServiceResult<bool> Delete(int id)
        {
            try
            {
                ExecuteNonQuery("DELETE FROM departements WHERE IdDepartement = @Id", new MySqlParameter("@Id", id));
                return ServiceResult<bool>.Success(true, "Département supprimé avec succès.");
            }
            catch (Exception ex) { return ServiceResult<bool>.Failure($"Erreur : {ex.Message}"); }
        }
    }
}
