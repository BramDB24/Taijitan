using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G07_Taijitan.Data.Mappers {
    public class LidSessieConfiguration : IEntityTypeConfiguration<LidSessie> {
        public void Configure(EntityTypeBuilder<LidSessie> builder) {
            builder.HasKey(ls => new { ls.Gebruikersnaam, ls.SessieDatum });
            builder.Property(ls => ls.Aanwezigheid).IsRequired();
            builder.HasOne(ls => ls.Lid).WithMany().HasForeignKey(ls=>ls.Gebruikersnaam).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ls => ls.Sessie).WithMany(ls => ls.Ledenlijst).HasForeignKey(ls=>ls.SessieDatum);
        }
    }
}
