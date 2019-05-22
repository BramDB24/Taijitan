using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G07_Taijitan.Data.Mappers {
    public class LidActiviteitConfiguration : IEntityTypeConfiguration<LidActiviteit> {
        public void Configure(EntityTypeBuilder<LidActiviteit> builder) {
            builder.HasKey(b => new { b.Gebruikersnaam, b.ActiviteitId });
            builder.HasOne(l => l.Activiteit).WithMany(a => a.Aanwezigen).HasForeignKey(l=> l.ActiviteitId);
            builder.HasOne(l => l.Lid).WithMany().HasForeignKey(l=> l.Gebruikersnaam);
        }
    }
}
