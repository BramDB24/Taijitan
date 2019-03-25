using G07_Taijitan.Models.Domain.Gebruiker;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    [JsonObject(MemberSerialization.OptIn)]
    public class LidSessie {
        public Sessie Sessie { get; set; }
        public Lid Lid { get; set; }
        public DateTime SessieDatum { get; set; }
        [JsonProperty]
        public string Gebruikersnaam { get; set; }
        [JsonProperty]
        public bool Aanwezigheid { get; set; }

        public LidSessie(Lid lid, Sessie sessie, bool aanwezigheid) {
            Lid = lid;
            Sessie = sessie;
            SessieDatum = sessie.SessieDatum;
            Gebruikersnaam = lid.Gebruikersnaam;
            Aanwezigheid = aanwezigheid;
        }

        public LidSessie() {

        }

        public void VeranderAanwezigheid() {
            Aanwezigheid = !Aanwezigheid;
        }
    }
}