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
    public class VideoConfig : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable("Videos", "sch");

            builder.Property(x => x.Quality)
                .IsRequired()
                .HasColumnName("Quality");


            builder.Property(x => x.Duration)
                .IsRequired()
                .HasColumnName("Duration");

           

            //builder.HasMany(dp=>dp.DirectoryPermissions)
            //    .WithOne(u=>u.User)
            //    .HasForeignKey(d => d.UserId)
            //    .HasConstraintName("FK_DeirectoryPermsissions_User")
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
