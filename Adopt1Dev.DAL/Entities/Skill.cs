using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopt1Dev.DAL.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategorieId { get; set; }

        public virtual Categorie Categorie { get; set; }
        public virtual IEnumerable<Notation> Notations { get; set; } 
    }
}
