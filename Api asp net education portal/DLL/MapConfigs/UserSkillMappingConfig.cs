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
    public class UserSkillMappingConfig : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder.ToTable("UserSkill", "sch");
            builder.HasKey(x => x.Id).HasName("PK_UserSkill").IsClustered();

            builder.Property(x => x.Level)
                .IsRequired()
                .HasColumnName("Level");

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId");

            builder.Property(x => x.SkillId)
                .IsRequired()
                .HasColumnName("SkillId");

            builder.HasOne(u=>u.User)
                .WithMany(s=>s.UserSkill).HasForeignKey(fk=>fk.UserId)
                .HasConstraintName("FK_Users_UserSkill")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Skill)
                .WithMany(us => us.UserSkills).HasForeignKey(fk => fk.SkillId)
                .HasConstraintName("FK_Skill_UserSkill")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
