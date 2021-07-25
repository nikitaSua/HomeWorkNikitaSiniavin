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
    public class MaterialMappingConfig : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Materials", "sch");
            builder.HasKey(x => x.Id).IsClustered();

            builder.Property(x => x.Name)
                .HasMaxLength(120)
                .IsRequired()
                .HasColumnName("Name");
            builder.Property(x => x.Description)
                .HasMaxLength(240)
                .IsRequired()
                .HasColumnName("Description");

            //builder.HasMany(dp=>dp.DirectoryPermissions)
            //    .WithOne(u=>u.User)
            //    .HasForeignKey(d => d.UserId)
            //    .HasConstraintName("FK_DeirectoryPermsissions_User")
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
