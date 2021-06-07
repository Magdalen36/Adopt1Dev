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
    public class TypeTarifConfiguration : IEntityTypeConfiguration<TypeTarif>
    {
        public void Configure(EntityTypeBuilder<TypeTarif> builder)
        {
            builder.ToTable(nameof(TypeTarif));
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired();

            //one to many tarif
            builder.HasMany(t => t.Tarifs)
                    .WithOne(t => t.TypeTarif)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
