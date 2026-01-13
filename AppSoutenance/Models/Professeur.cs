using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppSoutenance.Models
{
    public class Professeur:Utilisateur
    {

        [Required, MaxLength(80)]

        public string SpecialiteProfesseur { get; set; }
    }
}
