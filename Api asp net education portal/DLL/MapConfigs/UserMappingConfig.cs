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
    public class UserMappingConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "sch");
            builder.HasKey(x => x.Id).HasName("PK_Users").IsClustered();

            builder.Property(x => x.Login)
                .HasMaxLength(40)
                .IsRequired()
                .HasColumnName("Login");

            builder.Property(x => x.Password)
                .HasMaxLength(60)
                .IsRequired()
                .HasColumnName("Password");

            builder.Property(x => x.Name)
                .HasMaxLength(120)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(x => x.Email)
                .HasMaxLength(60)
                .IsRequired()
                .HasColumnName("Email");

            builder.HasOne(r=>r.Role)
                .WithMany(u=>u.Users).HasForeignKey(fk=>fk.RoleId)
                .HasConstraintName("FK_User_Role")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(dp=>dp.DirectoryPermissions)
            //    .WithOne(u=>u.User)
            //    .HasForeignKey(d => d.UserId)
            //    .HasConstraintName("FK_DeirectoryPermsissions_User")
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
