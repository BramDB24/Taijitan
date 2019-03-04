using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class GebruikerGraad {
        public string Gebruikersnaam { get; set; }
        public string Graadnaam { get; set; }
        public Graad Graad { get; set; }
        public Gebruiker Gebruiker { get; set; }

        protected GebruikerGraad() {

        }
    }
}
