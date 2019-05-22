using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G07_Taijitan.Data.Mappers {
    public class ActiviteitConfiguration : IEntityTypeConfiguration<Activiteit> {
        public void Configure(EntityTypeBuilder<Activiteit> builder) {
            builder.ToTable("Activiteit");
            builder.HasKey(a => a.ActiviteitId);
            builder.Property(a => a.Naam).IsRequired();
            builder.Property(a => a.StartDatum).IsRequired();
        }
    }
}
