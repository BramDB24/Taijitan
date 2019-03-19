using G07_Taijitan.Models.Domain.Gebruiker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain
{
    public class Sessie
    {
        public DateTime SessieDatum { get; set; }
        public IEnumerable<Lid> Aanwezigheden { get; set; }

    }
}
