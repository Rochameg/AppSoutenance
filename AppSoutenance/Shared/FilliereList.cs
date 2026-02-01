using AppSoutenance.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSoutenance.Shared
{
    public class FilliereList
    {
        BdSenSoutenanceContext db = new BdSenSoutenanceContext();

        public List<ListItem> FillAnneeAcademique()
        {
            List<ListItem> laListe = new List<ListItem>();
            var liste = db.anneeAcademiques.ToList();
            laListe.Add(new ListItem
            {
                Value = null,
                Text = "Selectionner"
            });
            foreach (var t in liste)
            {
                var item = new ListItem
                {
                    Value = t.IdAnneeAcademique.ToString(),
                    Text = t.LibelleAnneeAcademique.ToString()
                };
                laListe.Add(item);
            }
            return laListe;
        }

    }
}
