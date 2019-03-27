using G07_Taijitan.Models.Domain.Gebruiker;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Sessie
    {
        [JsonProperty]
        private ICollection<LidSessie> _ledenlijst = new List<LidSessie>();

        [JsonProperty]
        public DateTime SessieDatum { get; set; }
        public IEnumerable<LidSessie> Ledenlijst => _ledenlijst.AsEnumerable();
        public int Dag => (int)SessieDatum.DayOfWeek;
        public Sessie() {
            SessieDatum = DateTime.Now;
        }


        public void AddLid(Lid lid, bool aanwezigheid = false) {
            _ledenlijst.Add(new LidSessie(lid, this, aanwezigheid));
        }

        public void RegistreerAanwezigheden(IEnumerable<Lid> aanwezigheden, IEnumerable<Lid> afwezigeLeden) {
            foreach(var lid in aanwezigheden) {
                AddLid(lid, true);
                lid.verhoogPunten();
            }
            foreach(var lid in afwezigeLeden) {
                AddLid(lid);
            }
        }

        public IEnumerable<Lid> getAanwezigeLeden() {
            return Ledenlijst.Where(l=>l.Aanwezigheid).Select(l=>l.Lid).AsEnumerable();
        }
    }
}
