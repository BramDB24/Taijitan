using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G07_Taijitan.Data.Mappers {
    public class GebruikerOefeningConfiguration : IEntityTypeConfiguration<GebruikerOefening> {
        public void Configure(EntityTypeBuilder<GebruikerOefening> builder) {
            builder.ToTable("GebruikerOefening");
            builder.HasKey(t => t.GebruikerOefeningId);
            //builder.HasKey(t => new { t.Gebruikersnaam, t.OefeningId });
            builder.HasOne(g => g.Gebruiker).WithMany(g => g.Oefeningen).HasForeignKey(g=>g.Gebruikersnaam).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(g => g.Oefening).WithMany().HasForeignKey(g=>g.OefeningId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
