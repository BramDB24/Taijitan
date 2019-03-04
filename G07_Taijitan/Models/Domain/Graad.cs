using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class Graad {

        public string Naam { get; set;}
        //public string Image { get;}
        public ICollection<Oefening> Oefeningen { get; set;}

        public Graad() {
        }

        public Graad(string naam) {
            Naam = naam;
        }
    }
}
