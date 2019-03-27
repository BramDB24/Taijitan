using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G07_Taijitan.Data.Mappers {
    public class FormuleDagConfiguration : IEntityTypeConfiguration<FormuleDag> {
        public void Configure(EntityTypeBuilder<FormuleDag> builder) {
            builder.HasKey(fd => new { fd.DagNaam, fd.FormuleNaam });
            builder.HasOne(fd => fd.Dag).WithMany(d=>d.Formules).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(fd => fd.Formule).WithMany(f=>f.Dagen).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
