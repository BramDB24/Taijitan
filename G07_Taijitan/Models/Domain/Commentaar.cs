using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class Commentaar {
        public Gebruiker.Gebruiker Gebruiker { get; set; }
        public string Gebruikersnaam { get; set; }
        public LesMateriaal.Lesmateriaal Lesmateriaal { get; set; }
        public int LesmateriaalId { get; set; }
        public DateTime DateTime { get; set; }
        public string Tekst { get; set; }

        public Commentaar() {

        }

        public Commentaar(DateTime dateTime, string tekst) {
            DateTime = dateTime;
            Tekst = tekst;
        }

    }
}
