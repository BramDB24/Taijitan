using System.Collections.Generic;

namespace G07_Taijitan.Models.Domain.RepoInterface
{
    public interface IGebruikerRepository
    {
        IEnumerable<Gebruiker.Gebruiker> GetAllGebruikers();
        //Gebruiker GetByEmail(string email);
        //void AddGebruiker(Gebruiker gebruiker);
        //void RemoveGebruiker(Gebruiker gebruiker);
        void SaveChanges();
        Gebruiker.Gebruiker GetByGebruikernaam(string gebruikersnaam);
    }
}
