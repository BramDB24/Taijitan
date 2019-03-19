using G07_Taijitan.Models.Domain;
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.RepoInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Data.Repositories
{
    public class SessieRepository : ISessieRepository
    {
        private readonly DbSet<Sessie> _sessie;
        private readonly ApplicationDbContext _context;

        public SessieRepository(ApplicationDbContext context)
        {
            _context = context;
            _sessie = context.Sessies;
        }
        public IEnumerable<Lid> getAllLeden()
        {
            return (IEnumerable<Lid>)_sessie.ToList();   
        }
    }
}
