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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(false); //laisse passer les _ 

            builder.Property(u => u.Password).IsRequired();

            builder.Property(p => p.ImageMimeType).HasMaxLength(50);

            //many to one tarif
            builder.HasMany(t => t.Tarifs)
                    .WithOne(u => u.User)
                    .OnDelete(DeleteBehavior.Cascade);

            //one to many notation
            builder.HasMany(n => n.Notations)
                    .WithOne(u => u.User)
                    .OnDelete(DeleteBehavior.Cascade);


            builder.HasCheckConstraint("CK_Email", "Email LIKE '_%@_%'")
                   .HasIndex(u => u.Email) //Index pour l'unicité
                   .IsUnique();
        }
    }
}
