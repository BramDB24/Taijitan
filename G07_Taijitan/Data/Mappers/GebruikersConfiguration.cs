using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Data.Mappers
{
    public class GebruikersConfiguration : IEntityTypeConfiguration<Gebruiker>
    {
        /* change at 2402 email en wachtwoord coll toegevoegd in de databank */
        public void Configure(EntityTypeBuilder<Gebruiker> builder)
        {
            builder.ToTable("Gebruiker");
            builder.HasKey(t => t.Gebruikersnaam);
            builder.Property(t => t.Wachtwoord).IsRequired(true).HasMaxLength(50);
            builder.Property(t => t.Naam).IsRequired(true).HasMaxLength(50);
            builder.Property(t => t.Voornaam).IsRequired(true).HasMaxLength(50);
            builder.Property(t => t.Geboortedatum).IsRequired(true);
            builder.Property(t => t.Adres).IsRequired(false).HasMaxLength(50);
            builder.Property(t => t.Telefoonnummer).IsRequired(false).HasMaxLength(10);
            builder.Property(t => t.AuthorityNaam).IsRequired(true).HasMaxLength(50);
            builder.Property(t => t.Email).IsRequired(true).HasMaxLength(100);
            builder.Property(t => t.Graad).IsRequired(true);
        }
    }
}
