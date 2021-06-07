using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopt1Dev.DAL.Entities
{
    public class Tarif
    {
        public int Id { get; set; }
        
        public double Prix { get; set; }
        public int UserId { get; set; }
        public int TypeTarifId { get; set; }

        public virtual User User { get; set; }
        public virtual TypeTarif TypeTarif { get; set; }
    }
}
