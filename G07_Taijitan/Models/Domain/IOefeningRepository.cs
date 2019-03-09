using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain
{
    public interface IOefeningRepository
    {
        IEnumerable<Oefening> GetAll();        
        IEnumerable<Oefening> GetByGraad(int graad);
    }
}
