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
    public class VideoFileMapConf : IEntityTypeConfiguration<VideoFile>
    {
        public void Configure(EntityTypeBuilder<VideoFile> builder)
        {
            builder.ToTable("VideoFile");

            builder.Property(x => x.Height).HasColumnName("Height");
            builder.Property(x => x.Width).HasColumnName("Width");
            builder.Property(x => x.Duration).HasColumnName("Duration");
        }
    }
}
