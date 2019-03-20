using G07_Taijitan.Models.Domain.Gebruiker;
using System.Collections.Generic;

namespace G07_Taijitan.Models.Domain.RepoInterface
{
    public interface IGebruikerRepository
    {
        IEnumerable<Gebruiker.Gebruiker> GetAllGebruikers();
        void SaveChanges();
        Gebruiker.Gebruiker GetByGebruikernaam(string gebruikersnaam);
        IEnumerable<Lid> GetAllLeden();
    }
}
