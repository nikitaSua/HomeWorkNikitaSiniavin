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
    public class FileMapConfig : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable("File", "sch");

            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.Property(x => x.Title)
                .HasMaxLength(120);

            builder.Property(x => x.Extension)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Size)
                .HasMaxLength(20)
                .IsRequired();

            //builder.HasOne(tf => tf.TextFile).WithOne(p => p.File).HasForeignKey<TextFile>(tf => tf.Id);


            builder.HasOne(d=>d.Directorie).WithMany(f=>f.Files).HasForeignKey(d=>d.DirectoryId).HasConstraintName("FK_Deirectory_file").OnDelete(DeleteBehavior.SetNull);
        }
    }
}
