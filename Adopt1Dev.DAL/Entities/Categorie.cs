using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopt1Dev.DAL.Entities
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Skill> Skills { get; set; }
    }
}
