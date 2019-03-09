using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G07_Taijitan.Data.Mappers
{
    public class OefeningTypeConfiguration : IEntityTypeConfiguration<OefeningType>
    {
        public void Configure(EntityTypeBuilder<OefeningType> builder)
        {
            builder.HasKey(t => t.TypeId);
            builder.Property(t => t.TypeNaam).IsRequired();
            //builder.HasMany(o => o.OefeningenReeks).WithOne().HasForeignKey(t => t.TypeId);
        }
    }
}
