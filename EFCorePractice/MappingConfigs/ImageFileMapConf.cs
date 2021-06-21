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
    public class ImageFileMapConf : IEntityTypeConfiguration<ImageFile>
    {
        public void Configure(EntityTypeBuilder<ImageFile> builder)
        {
            builder.ToTable("ImageFile");

            builder.Property(x => x.Heigth).HasColumnName("Heigth");
            builder.Property(x => x.Width).HasColumnName("Width");
        }
    }
}
