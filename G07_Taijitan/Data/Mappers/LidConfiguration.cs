using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G07_Taijitan.Data.Mappers {
    public class LidConfiguration : IEntityTypeConfiguration<Lid> {
        public void Configure(EntityTypeBuilder<Lid> builder) {
            
        }
    }
}
