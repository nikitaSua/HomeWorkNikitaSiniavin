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
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books", "sch");

            builder.Property(x => x.NumOfPage)
                .IsRequired()
                .HasColumnName("NumOfPage");
            builder.Property(x => x.YearOfPublishing)
                .IsRequired()
                .HasColumnName("YearOfPublishing");

            builder.HasMany(a => a.AutorBooks)
                .WithOne(b => b.Book)
                .HasForeignKey(ab => ab.BookId)
                .HasConstraintName("FK_AuthorBook_Book")
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
