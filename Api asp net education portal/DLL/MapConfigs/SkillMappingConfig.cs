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
    public class SkillMappingConfig : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills", "sch");
            builder.HasKey(x => x.Id).HasName("PK_Skill").IsClustered();

            builder.Property(x => x.Name)
                .HasMaxLength(80)
                .IsRequired()
                .HasColumnName("Name");


            //builder.HasMany(dp=>dp.DirectoryPermissions)
            //    .WithOne(u=>u.User)
            //    .HasForeignKey(d => d.UserId)
            //    .HasConstraintName("FK_DeirectoryPermsissions_User")
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
