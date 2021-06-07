using Adopt1Dev.DAL.Entities;
using Adopt1Dev.DAL.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopt1Dev.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Notation> Notations { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }
        public DbSet<User> Users { get; set; }

        private readonly string _defaultConnectionString = @"Server=localhost;Database=Adopt1DevDB;Integrated Security=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_defaultConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuration
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategorieConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new NotationConfiguration());
            modelBuilder.ApplyConfiguration(new TarifConfiguration());

            //dataset
            //modelBuilder.ApplyConfiguration(new DataSetSkill());
        }
    }
}
