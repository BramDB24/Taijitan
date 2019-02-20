using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain
{
    public class Gebruiker
    {
        #region Properties

        public String Gebruikersnaam { get; set; }
        public String Wachtwoord { get; set; }
        public String Naam { get; set; }
        public String Voornaam { get; set; }
        public String Adres { get; set; }
        public String Telefoonnummer { get; set; }
        public String AuthorityNaam { get; set; }
        public DateTime Geboortedatum { get; set; }

        #endregion

        //nodig voor het aanmaken van een nieuwe gebruiker
        #region Constructors
        protected Gebruiker()
        {

        }
        public Gebruiker(string naam, string voornaam, string adres, string telefoonnumer, string authorityNaam, DateTime geboortedatum)
        {
            this.Naam = naam;
            this.Voornaam = voornaam;
            this.Adres = adres;
            this.Telefoonnummer = telefoonnumer;
            this.AuthorityNaam = authorityNaam;
            this.Geboortedatum = geboortedatum;
        }
        #endregion
    }
}
