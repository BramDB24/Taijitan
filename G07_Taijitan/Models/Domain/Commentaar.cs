using G07_Taijitan.Models.Domain.LesMateriaal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class Commentaar {
        public Gebruiker.Gebruiker Gebruiker { get; set; }
        public int CommentaarId { get; set; }
        public string Gebruikersnaam { get; set; }
        public Oefening Oefening { get; set; }
        public int OefeningId { get; set; }
        public DateTime DateTime { get; set; }
        public string Tekst { get; set; }

        public Commentaar() {

        }

        public Commentaar(Gebruiker.Gebruiker gebruiker, Oefening oefening, string tekst) {
            Gebruiker = gebruiker;
            Oefening = oefening;
            Gebruikersnaam = gebruiker.Gebruikersnaam;
            OefeningId = oefening.OefeningId;
            DateTime = DateTime.Now;
            Tekst = tekst;
        }

    }
}
