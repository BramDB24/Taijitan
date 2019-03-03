using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.Property(t => t.Geboorteplek).IsRequired(true).HasMaxLength(100);
            builder.Property(t => t.Land).IsRequired(true).HasMaxLength(100);
            builder.Property(t => t.Rijksregisternummer).IsRequired(true).HasMaxLength(20);

            builder.Property(t => t.Adres).IsRequired(false).HasMaxLength(50);
            builder.Property(t => t.Stad).IsRequired(true).HasMaxLength(100);
            builder.Property(t => t.Straatnaam).IsRequired(true).HasMaxLength(150);
            builder.Property(t => t.Postcode).IsRequired(true).HasMaxLength(100);
            builder.Property(t => t.Huisnummer).IsRequired(true).HasMaxLength(5);

            builder.Property(t => t.Telefoonnummer).IsRequired(false).HasMaxLength(9);
            builder.Property(t => t.Gsm).IsRequired(true).HasMaxLength(10);

            builder.Property(t => t.Email).IsRequired(true).HasMaxLength(150);
            builder.Property(t => t.EmailOuders).IsRequired(false).HasMaxLength(150);

            builder.Property(t => t.Graad).IsRequired(true);
            builder.Property(t => t.InschrijvingsDatum).IsRequired(true);


            builder.HasDiscriminator<string>("Rol")
                .HasValue<Lid>("Lid")
                .HasValue<Beheerder>("Beheerder")
                .HasValue<Lesgever>("Lesgever");
        }
    }
}
