using System;
using System.Collections.Generic;
using System.Text;
using G07_Taijitan.Data.Mappers;
using G07_Taijitan.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace G07_Taijitan.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        #region DbSets
        public DbSet<Gebruiker> gebruikers { get; set; }   
        public DbSet<Graad> graden { get; set; }
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
            : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new GebruikersConfiguration());
            builder.ApplyConfiguration(new GraadConfiguration());
            builder.ApplyConfiguration(new OefeningConfiguration());
            builder.ApplyConfiguration(new GebruikerGraadConfiguration());
        }
    }
}
