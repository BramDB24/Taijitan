using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.RepoInterface;

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
            _gebruikers = _context.Gebruikers;
        }
        

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Gebruiker> GetAllGebruikers()
        {
            return _gebruikers.ToList();
        }

        public Gebruiker GetByGebruikernaam(string gebruikersnaam)
        {
            return _gebruikers.FirstOrDefault(t => t.Gebruikersnaam ==gebruikersnaam);
        }

        public Lid GetLidByGebruikersnaam(string gebruikersnaam) {
            return _gebruikers.OfType<Lid>().Include(g=>g.Formule).ThenInclude(g=>g.Dagen).FirstOrDefault(t => t.Gebruikersnaam == gebruikersnaam); //added omdat ik formule hierbij moet includen.
        }
        
        public IEnumerable<Lid> GetLedenVoorSessieOp(int dag) { 
            return _gebruikers.OfType<Lid>().Where(g=>g.Formule.Dagen.Select(d=>(int)d.Dag.Naam).Contains(dag));
        }
    }
}
