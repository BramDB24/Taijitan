using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class GebruikerOefening {
        public int GebruikerOefeningId { get; set; }
        public Oefening Oefening { get; set; }
        public Gebruiker.Gebruiker Gebruiker { get; set; }
        public string Gebruikersnaam { get; set; }
        public int OefeningId { get; set; }
        public DateTime RaadpleegTijdstip { get; set; }

        public GebruikerOefening(int oefeningid, Gebruiker.Gebruiker gebruiker)
        {
            OefeningId = oefeningid;
            Gebruiker = gebruiker;
            RaadpleegTijdstip = DateTime.Now;
        }

        protected GebruikerOefening()
        {

        }
    }
}

