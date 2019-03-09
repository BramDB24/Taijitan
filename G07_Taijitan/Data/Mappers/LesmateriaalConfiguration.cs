using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Models.Domain.LesMateriaal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G07_Taijitan.Data.Mappers {
    public class LesmateriaalConfiguration : IEntityTypeConfiguration<Lesmateriaal> {
        public void Configure(EntityTypeBuilder<Lesmateriaal> builder) {
            builder.HasKey(l => l.LesmateriaalId);
            builder.Property(l => l.Naam);
            builder.HasDiscriminator<string>("Type")
                .HasValue<Video>("Video")
                .HasValue<Foto>("Foto")
                .HasValue<Tekst>("Tekst");
        }
    }
}
