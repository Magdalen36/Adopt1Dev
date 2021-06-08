using Adopt1Dev.ASP.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adopt1Dev.ASP.Models.Form
{
    public class UserForm
    {

        IService<SkillModel, SkillForm> _skillService;
        public UserForm(IService<SkillModel, SkillForm> service)
        {
            _skillService = service;
        }

        public UserForm()
        {

        }

        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(9, ErrorMessage = "Votre mot de passe doit contenir minimum 9 caractères")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Vos mots de passe ne correspondent pas")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }

        public List<int> SkillIds { get; set; }

        public IEnumerable<SkillModel> LesSkills
        {
            get { return SkillService?.GetAll(); }
        }

        public IService<SkillModel, SkillForm> SkillService
        {
            private get { return _skillService; }
            set
            {
                _skillService = value;
            }
        }
    }
}
