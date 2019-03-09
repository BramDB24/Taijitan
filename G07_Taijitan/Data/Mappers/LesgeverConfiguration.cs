using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Models.Domain.Gebruiker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G07_Taijitan.Data.Mappers {
    public class LesgeverConfiguration : IEntityTypeConfiguration<Lesgever> {
        public void Configure(EntityTypeBuilder<Lesgever> builder) {
            
        }
    }
}
