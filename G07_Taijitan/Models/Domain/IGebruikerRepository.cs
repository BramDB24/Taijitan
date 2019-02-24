using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain
{
    public interface IGebruikerRepository
    {
        IEnumerable<Gebruiker> GetAllGebruikers();
        Gebruiker GetByEmail(string email);
        void AddGebruiker(Gebruiker gebruiker);
        void RemoveGebruiker(Gebruiker gebruiker);
        void SaveChanges();
        Gebruiker GetByGebruikernaam(string naam);
    }
}
