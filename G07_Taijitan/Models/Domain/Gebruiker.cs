using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain
{
    public class Gebruiker
    {
        #region Properties
        private string gebruikersnaam, wachtwoord, naam, voornaam, adres, telefoonnumer, authorityNaam;
        private DateTime geboorteDatum;
        #endregion

        //nodig voor het aanmaken van een nieuwe gebruiker
        #region Constructors
        public Gebruiker(string gebruikersnaam, string wachtwoord, string naam, string voornaam, string adres, string telefoonnumer, string authorityNaam, DateTime geboortedatum)
        {
            this.gebruikersnaam = gebruikersnaam;
            this.wachtwoord = wachtwoord;
            this.naam = naam;
            this.voornaam = voornaam;
            this.adres = adres;
            this.telefoonnumer = telefoonnumer;
            this.authorityNaam = authorityNaam;
            this.geboorteDatum = geboortedatum;
        } 
        #endregion
    }
}
