using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppSoutenance.Models
{
    public class Utilisateur
    {

        [Key]
        public int IdUtilisateur { get; set; }

        [Required, MaxLength(80)]
        public string NomUtilisateur { get; set; }

        [Required, MaxLength(80)]
        public string PrenomUtilisateur { get; set; }

        [Required, MaxLength(15)]
        public string TelUtilisateur { get; set; }

        [Required, MaxLength(80), DataType(DataType.EmailAddress)]
        public string EmailUtilisateur { get; set; }

        [Required, MaxLength(300)]
        public string MotDeUtilisateur { get; set; }
    }
}
