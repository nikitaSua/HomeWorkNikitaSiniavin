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
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles", "sch");

            builder.Property(x => x.PublicationDate)
                .IsRequired()
                .HasColumnName("PublicationDate");


            builder.Property(x => x.Link)
                .HasMaxLength(120)
                .IsRequired()
                .HasColumnName("Link");

           

            //builder.HasMany(dp=>dp.DirectoryPermissions)
            //    .WithOne(u=>u.User)
            //    .HasForeignKey(d => d.UserId)
            //    .HasConstraintName("FK_DeirectoryPermsissions_User")
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
