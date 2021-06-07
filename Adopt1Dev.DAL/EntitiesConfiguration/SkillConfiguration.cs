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
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable(nameof(Skill));

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
            //builder.Property(s => s.CategorieId).IsRequired();

            //one to many notation
            builder.HasMany(n => n.Notations)
                    .WithOne(s => s.Skill)
                    .OnDelete(DeleteBehavior.Cascade);

            //one to many categorie
            builder.HasOne(c => c.Categorie)
                    .WithMany(s => s.Skills)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    
    }
}
