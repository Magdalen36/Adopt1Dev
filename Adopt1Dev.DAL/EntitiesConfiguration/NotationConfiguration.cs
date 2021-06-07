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
    public class NotationConfiguration : IEntityTypeConfiguration<Notation>
    {
        public void Configure(EntityTypeBuilder<Notation> builder)
        {
            builder.ToTable(nameof(Notation));
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Note).IsRequired();
            builder.Property(n => n.SkillId).IsRequired();
            builder.Property(n => n.UserId).IsRequired();
        }
    }
}
