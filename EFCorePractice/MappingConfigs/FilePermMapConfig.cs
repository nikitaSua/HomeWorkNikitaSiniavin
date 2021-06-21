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

    public class FilePermMapConfig : IEntityTypeConfiguration<FilePermission>
    {
        public void Configure(EntityTypeBuilder<FilePermission> builder)
        {
            builder.ToTable("FilePermissions", "sch");
            builder.HasKey(x => new { x.UserId, x.Id });

            builder.HasOne(u => u.User)
                .WithMany(d => d.FilePermissions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_FilePermsissions_User")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(f=>f.File).WithMany(p=>p.FilePermissions).HasForeignKey(p=>p.Id)
                .HasConstraintName("FK_FilePermsissions_File")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CanRead).IsRequired().HasColumnType("bit");
            builder.Property(x => x.CanWrite).IsRequired().HasColumnType("bit");
        }
    }
}
