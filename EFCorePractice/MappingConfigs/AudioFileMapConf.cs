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
    public class AudioFileMapConf : IEntityTypeConfiguration<AudioFile>
    {
        public void Configure(EntityTypeBuilder<AudioFile> builder)
        {
            builder.ToTable("AudioFile");

            builder.Property(x => x.Bitrate).HasColumnName("Bitrate").HasMaxLength(120);
            builder.Property(x => x.SampleRate).HasColumnName("SampleRate").HasMaxLength(120);
            builder.Property(x => x.ChannelCount).HasColumnName("ChannelCount");
            builder.Property(x => x.Duration).HasColumnName("Duration").HasColumnType("time");
        }
    }
}
