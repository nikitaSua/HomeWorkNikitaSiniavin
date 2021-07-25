using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MappingConfigs
{
    // для указания натроек реализуем интерфейс IEntityTypeConfiguration < сущность >
    public class RoleMappingConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "sch");
            builder.HasKey(x => x.Id).HasName("PK_Role").IsClustered();

            builder.Property(x => x.Name)
                .HasMaxLength(40)
                .IsRequired()
                .HasColumnName("Name");
        }
    }
}
