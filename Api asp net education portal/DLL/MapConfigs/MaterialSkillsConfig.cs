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
    public class MaterialSkillConfig : IEntityTypeConfiguration<MaterialSkill>
    {
        public void Configure(EntityTypeBuilder<MaterialSkill> builder)
        {
            builder.ToTable("MaterialSkill", "sch");
            builder.HasKey(x => x.Id).HasName("PK_MaterialSkill").IsClustered();

            builder.Property(x => x.Level)
                .IsRequired()
                .HasColumnName("Level");


            builder.HasOne(m=>m.Material)
                .WithMany(ms=>ms.MaterialSkills)
                .HasForeignKey(msk=>msk.MaterialId)
                .HasConstraintName("FK_MaterialSkill_Material")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Skill)
                .WithMany(ms => ms.MaterialSkills)
                .HasForeignKey(msk => msk.SkillId)
                .HasConstraintName("FK_MaterialSkill_Skill")
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
