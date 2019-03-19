using G07_Taijitan.Models.Domain.Gebruiker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class LidSessie {
        public Sessie Sessie { get; set; }
        public Lid Lid { get; set; }
        public DateTime SessieDatum { get; set; }
        public string Gebruikersnaam { get; set; }
        public bool Aanwezigheid { get; set; }

        public LidSessie(Lid lid, Sessie sessie) {
            Lid = lid;
            Sessie = sessie;
            SessieDatum = sessie.SessieDatum;
            Gebruikersnaam = lid.Gebruikersnaam;
            Aanwezigheid = false;
        }

        public LidSessie() {

        }
    }
}