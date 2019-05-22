using G07_Taijitan.Models.Domain.Gebruiker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class LidActiviteit {
        public Lid Lid { get; set; }
        public Activiteit Activiteit { get; set; }
        public String Gebruikersnaam { get; set; }
        public int ActiviteitId { get; set; }

        public LidActiviteit() {

        }

        public LidActiviteit(Lid lid, Activiteit activiteit) {
            Lid = lid;
            Activiteit = activiteit;
            Gebruikersnaam = lid.Gebruikersnaam;
            ActiviteitId = activiteit.ActiviteitId;
        }
    }
}
