using System;
using System.Collections.Generic;
using System.Linq;

namespace G07_Taijitan.Models.Domain.Gebruiker {
    public class Lid : Gebruiker {
        public Formule Formule { get; set; }
        public int Score { get; set; }
        public Lid() {
        }

        public void verhoogPunten() {
            if(Formule.Dagen.Count() == 1) {
                Score += 10;
            } else
                Score += 5;
        }
    }
}
