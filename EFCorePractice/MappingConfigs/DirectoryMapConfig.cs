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
    public class DirectorieMapConfig : IEntityTypeConfiguration<Directorie>
    {
        public void Configure(EntityTypeBuilder<Directorie> builder)
        {
            builder.ToTable("Directorie", "sch");
            builder.HasKey(x => x.Id)
                .HasName("PK_Direktory")
                .IsClustered();

            builder.Property(x => x.Title)
                .HasMaxLength(120);



        }
    }
}
