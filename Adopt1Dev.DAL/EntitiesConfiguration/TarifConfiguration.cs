using Adopt1Dev.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopt1Dev.DAL.EntitiesConfiguration
{
    public class TarifConfiguration : IEntityTypeConfiguration<Tarif>
    {
        public void Configure(EntityTypeBuilder<Tarif> builder)
        {
            builder.ToTable(nameof(Tarif));
            builder.HasKey(t => t.Id);

            
            builder.Property(t => t.Prix).IsRequired();
            builder.Property(t => t.UserId).IsRequired();           
            builder.Property(t => t.TypeTarifId).IsRequired();           
        }
    }
}
