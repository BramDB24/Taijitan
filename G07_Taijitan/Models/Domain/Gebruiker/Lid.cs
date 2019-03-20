using System;
using System.Collections.Generic;

namespace G07_Taijitan.Models.Domain.Gebruiker {
    public class Lid : Gebruiker{

        public Formule Formule { get; set; }
        public int Score { get; set; }
        public Lid() {
        }
    }
}
