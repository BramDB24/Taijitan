using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain
{
    public interface IGraadRepository
    {
        IEnumerable<Graad> GetAll();
        IEnumerable<int> GetAvailable(int graad, Gebruiker gebruiker);
    }
}
