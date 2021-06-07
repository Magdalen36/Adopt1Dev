using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopt1Dev.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }

        public virtual IEnumerable<Tarif> Tarifs {get; set;}
        public virtual IEnumerable<Notation> Notations {get; set;}
    }
}
