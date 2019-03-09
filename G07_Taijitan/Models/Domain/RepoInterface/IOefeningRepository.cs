using System.Collections.Generic;

namespace G07_Taijitan.Models.Domain.RepoInterface
{
    public interface IOefeningRepository
    {
        IEnumerable<Oefening> GetAll();        
        IEnumerable<Oefening> GetByGraad(int graad);
        IEnumerable<Oefening> GetByType(int type);
    }
}
