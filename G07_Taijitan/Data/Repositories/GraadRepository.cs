using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Data.Repositories
{
    public class GraadRepository : IGraadRepository
    {
        private readonly DbSet<Graad> _graad;
        public GraadRepository(ApplicationDbContext context)
        {
            _graad = context.graden;
        }
        public IEnumerable<Graad> GetAll()
        {
            return _graad.ToList();
        }

        public IEnumerable<int> GetAvailable(int graad, Gebruiker gebruiker)
        {
           return Enum.GetValues(typeof(Graad)).Cast<int>().Where(t => gebruiker.Graad >= t).ToList(); //<big oof
        }
    }
}