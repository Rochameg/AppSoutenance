using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppSoutenance.Models
{
    public class Candidat:Utilisateur
    {

        [Required, MaxLength(20)]
        public string MatriculeCandidat { get; set; }
    }
}
