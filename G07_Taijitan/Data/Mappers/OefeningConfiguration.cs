using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G07_Taijitan.Data.Mappers {
    public class OefeningConfiguration : IEntityTypeConfiguration<Oefening> {
        public void Configure(EntityTypeBuilder<Oefening> builder) {
            builder.HasKey(b => b.OefeningId);
            builder.Property(o => o.Naam).IsRequired();
        }
    }
}
