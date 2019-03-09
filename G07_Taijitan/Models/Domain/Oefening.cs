using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class Oefening {
        public int OefeningId { get; set; }

        public string Naam { get; set; }

        public Graad Graad { get; set; }

        public IEnumerable<Lesmateriaal> Lesmateriaal { get; set; }

        public Oefening() { }
        
        
    }
}
