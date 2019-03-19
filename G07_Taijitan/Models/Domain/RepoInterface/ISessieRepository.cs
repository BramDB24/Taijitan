using G07_Taijitan.Models.Domain.Gebruiker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain.RepoInterface
{
    public interface ISessieRepository
    {
        IEnumerable<Lid> getAllLeden();
    }
}
