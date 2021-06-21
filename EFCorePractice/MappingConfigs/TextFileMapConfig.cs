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
    public class TextFileMapConfig : IEntityTypeConfiguration<TextFile>
    {
        public void Configure(EntityTypeBuilder<TextFile> builder)
        {
            builder.ToTable("TextFile");
            builder.Property(x => x.Content)
                .HasMaxLength(120)
                .IsRequired()
                .HasColumnName("ContentDB");
        }
    }
}
