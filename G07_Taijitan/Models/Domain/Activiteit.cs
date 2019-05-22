using G07_Taijitan.Models.Domain.Gebruiker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class Activiteit {
        private ICollection<LidActiviteit> _aanwezigen = new List<LidActiviteit>();
        public int ActiviteitId { get; set; }
        public String Naam { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int MaxAantal { get; set; }
        public IEnumerable<LidActiviteit> Aanwezigen => _aanwezigen.AsEnumerable();

        public Activiteit() {

        }

        public void AddLid(Lid lid) {
            _aanwezigen.Add(new LidActiviteit(lid, this));
        }
    }
}
