using EFCorePractice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPractice.Date.Core.MappingConfigs
{
    // для указания натроек реализуем интерфейс IEntityTypeConfiguration < сущность >
    public class UserMappingConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "sch");
            builder.HasKey(x => x.Id).HasName("PK_Users").IsClustered();

            builder.Property(x => x.UserName)
                .HasMaxLength(120)
                .IsRequired()
                .HasColumnName("UserName");

            builder.Property(x => x.Email)
                .HasMaxLength(60)
                .IsRequired()
                .HasColumnName("Email");

            builder.Property(x => x.PaswordHash)
                .HasMaxLength(120)
                .IsRequired()
                .HasColumnName("PaswordHash");

            builder.HasMany(dp=>dp.DirectoryPermissions)
                .WithOne(u=>u.User)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_DeirectoryPermsissions_User")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
