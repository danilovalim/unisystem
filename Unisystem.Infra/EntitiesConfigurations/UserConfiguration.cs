using System;
using System.Data.Entity.ModelConfiguration;
using Unisystem.Domain.Entities;

namespace Unisystem.Infra.EntitiesConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(20);

            Property(c => c.Created)
                .IsRequired();
        }
    }
}
