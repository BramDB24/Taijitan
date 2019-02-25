using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        /* change at 2402 getbyemail methode toegevoegd */
        private readonly DbSet<Gebruiker> _gebruikers;
        private readonly ApplicationDbContext _context;

        public GebruikerRepository(ApplicationDbContext context)
        {
            _context = context;
            _gebruikers = _context.gebruikers;
        }

        public void AddGebruiker(Gebruiker gebruiker)
        {
            _gebruikers.Add(gebruiker);
        }

        public void RemoveGebruiker(Gebruiker gebruiker)
        {
            _gebruikers.Remove(gebruiker);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Gebruiker> GetAllGebruikers()
        {
            return _gebruikers.ToList();
        }

        public Gebruiker GetByEmail(string email)
        {
            return _gebruikers.FirstOrDefault(t => t.Email.Equals(email));
        }

        public Gebruiker GetByGebruikernaam(string gebruikersnaam)
        {
            return _gebruikers.FirstOrDefault(t => t.Gebruikersnaam.Equals(gebruikersnaam));
        }
    }
}
