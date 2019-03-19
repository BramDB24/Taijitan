using G07_Taijitan.Models.Domain.Gebruiker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain
{
    public class Sessie
    {
        public DateTime SessieDatum { get; set; }
        public ICollection<LidSessie> Ledenlijst { get; set; }

        public Sessie() {

        }

        public Sessie(IEnumerable<Lid> leden) {
            SessieDatum = DateTime.Now;
            Ledenlijst = new List<LidSessie>();    
            foreach(var lid in leden) {
                AddLid(lid);
            }
        }

        public void AddLid(Lid lid) {
            Ledenlijst.Add(new LidSessie(lid, this));
        }
    }
}
