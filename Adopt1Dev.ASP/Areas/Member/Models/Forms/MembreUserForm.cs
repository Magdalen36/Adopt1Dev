using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adopt1Dev.ASP.Areas.Member.Models.Forms
{
    public class MembreUserForm
    {
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }

        /*public IEnumerable<SkillModel> LesSkills
        {
            get
            {
                return _skillServices?.GetAll();
            }
        }*/
    }
}
