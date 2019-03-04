using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G07_Taijitan.Data.Mappers {
    public class GebruikerGraadConfiguration : IEntityTypeConfiguration<GebruikerGraad> {
        public void Configure(EntityTypeBuilder<GebruikerGraad> builder) {
            builder.HasKey(b => new { b.Gebruikersnaam, b.Graadnaam });
            builder.HasOne(g => g.Gebruiker)
                .WithMany(t => t.Graden)
                .HasForeignKey(t => t.Gebruikersnaam)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(g => g.Graad)
                .WithMany()
                .HasForeignKey(t => t.Graadnaam)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
