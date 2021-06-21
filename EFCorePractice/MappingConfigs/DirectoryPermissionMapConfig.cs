
using EFCorePractice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractice.MappingConfigs
{
    public class DirectoryPermissionMapConfig : IEntityTypeConfiguration<DirectoryPermission>
    {
        public void Configure(EntityTypeBuilder<DirectoryPermission> builder)
        {
            builder.ToTable("DirectoryPermissions", "sch");
            builder.HasKey(x => new {x.Id, x.UserId });

            builder.HasOne(d => d.Directorie)
                .WithMany(dp => dp.DirectoryPermissions)
                .HasForeignKey(dp => dp.Id)
                .HasConstraintName("FK_DeirectoryPermsissions_Directory")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CanRead).IsRequired().HasColumnType("bit");
            builder.Property(x => x.CanWrite).IsRequired().HasColumnType("bit");
        }
    }
}
