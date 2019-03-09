using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class GebruikerOefening {        
        public Oefening Oefening { get; set; }
        public Gebruiker.Gebruiker Gebruiker { get; set; }
        public string Gebruikersnaam { get; set; }
        public int OefeningId { get; set; }
    }
}
