using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G07_Taijitan.Data.Mappers {
    public class CommentaarConfiguration : IEntityTypeConfiguration<Commentaar> {
        public void Configure(EntityTypeBuilder<Commentaar> builder) {
            builder.HasKey(c => new { c.Gebruikersnaam, c.LesmateriaalId});            
            builder.HasOne(c => c.Gebruiker).WithMany().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Lesmateriaal).WithMany().OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
