using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adopt1Dev.ASP.Models.Form
{
    public class SkillForm
    {
        public int Id { get; set; }

        //on peut personnaliser les messages d'erreurs
        [Required(ErrorMessage = "Ce champs est requis")]
        [MaxLength(50, ErrorMessage = "Le champs doit faire maximul 50 caractères.")]
        public string Name { get; set; }

        
    }
}
