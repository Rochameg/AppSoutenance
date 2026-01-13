using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppSoutenance.Models
{
    public class Departement
    {

        [Key]
        public int IdDepartement { get; set; }

        [Required, MaxLength(80)]

        public string LibelleDepartement { get; set; }
    }
}
