﻿using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
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

        public IEnumerable<Gebruiker> GetGetAllGebruikers()
        {
            return _gebruikers.ToList();
        }

        public Gebruiker GetGebruikersnaam(string naam)
        {
            return _gebruikers.FirstOrDefault(t => t.Naam.Equals(naam));
        }
    }
}
