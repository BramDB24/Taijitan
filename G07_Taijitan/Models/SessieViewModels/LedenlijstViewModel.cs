using G07_Taijitan.Models.Domain;
using G07_Taijitan.Models.Domain.Gebruiker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.SessieViewModels {
    public class LedenlijstViewModel {

        public ICollection<Lid> AanwezigeLeden { get; set; }
        public ICollection<Lid> AfwezigeLeden { get; set; }
        public LedenlijstViewModel(IEnumerable<LidSessie> ledenLijst) : this(){            
            vulLijsten(ledenLijst);
        }

        public LedenlijstViewModel() {
            AfwezigeLeden = new List<Lid>();
            AanwezigeLeden = new List<Lid>();
        }

        private void vulLijsten(IEnumerable<LidSessie> ledenLijst) {
            foreach(var lid in ledenLijst) {
                if(lid.Aanwezigheid) {
                    AanwezigeLeden.Add(lid.Lid);
                } else
                    AfwezigeLeden.Add(lid.Lid);
            }
        }
    }
}
