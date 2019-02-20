using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain
{
    public interface IGebruikerRepository
    {
        IEnumerable<Gebruiker> GetGetAllGebruikers();
        Gebruiker GetGebruikersnaam(string naam);
        void AddGebruiker(Gebruiker gebruiker);
        void RemoveGebruiker(Gebruiker gebruiker);
        void SaveChanges();
    }
}
