using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppSoutenance.Models
{
    public class ChefDepartement:Utilisateur
    {

        public int? IdDepartement { get; set; }

        [ForeignKey("IdDepartement")]
        public virtual Departement Departement { get; set; }
    }
}
