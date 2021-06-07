using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopt1Dev.DAL.Entities
{
    public class Notation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }

        public int Note { get; set; }

        public virtual User User { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
