using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public abstract class Lesmateriaal {
        public int LesmateriaalId { get; set; }
        public string Naam { get; set; }        

        public Lesmateriaal() {
        }

    }
}
