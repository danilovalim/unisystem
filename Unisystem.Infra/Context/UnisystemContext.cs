using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Unisystem.Domain.Entities;
using Unisystem.Infra.EntitiesConfigurations;

namespace Unisystem.Infra.Context
{
    public class UnisystemContext : DbContext
    {
        public UnisystemContext() : base("Unisystem")
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
