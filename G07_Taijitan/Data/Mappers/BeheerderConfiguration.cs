using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain.Gebruiker;

namespace G07_Taijitan.Data.Mappers {
    public class BeheerderConfiguration : IEntityTypeConfiguration<Beheerder> {
        public void Configure(EntityTypeBuilder<Beheerder> builder) {
            
        }
    }
}
