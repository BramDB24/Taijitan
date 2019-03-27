using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace G07_Taijitan.Data.Mappers {
    public class DagConfiguration : IEntityTypeConfiguration<Dag> {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Dag> builder) {
            builder.HasKey(d => d.Naam);
        }
    }
}
