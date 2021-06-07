﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adopt1Dev.ASP.Models.Form
{
    public class UserForm
    {
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
    }
}
