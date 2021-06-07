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
    public class CategorieConfiguration : IEntityTypeConfiguration<Categorie>
    {
        public void Configure(EntityTypeBuilder<Categorie> builder)
        {
            builder.ToTable(nameof(Categorie));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired();
        }
    }
}
