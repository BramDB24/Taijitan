using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.SessieViewModels {
    public class AanwezigheidViewModel {
        public string Gebruikersnaam { get; set; }        
        public string Naam { get; set; }
        public bool Aanwezigheid { get; set; }

        public AanwezigheidViewModel(string gebruikersnaam, string naam) {
            Gebruikersnaam = gebruikersnaam;            
            Naam = naam;
            Aanwezigheid = false;

        }
    }
}
