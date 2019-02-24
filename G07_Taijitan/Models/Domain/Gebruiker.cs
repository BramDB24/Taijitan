using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain
{
    public class Gebruiker
    {
        /* change at 2402 dropped ctor, util van prop */
        #region Properties

        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Adres { get; set; }
        public string Telefoonnummer { get; set; }
        public string AuthorityNaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Email { get; set; }
        public int Graad { get; set; }
        #endregion

        //nodig voor het aanmaken van een nieuwe gebruiker
        #region Constructors
        public Gebruiker()
        {

        }
        //public Gebruiker(string naam, string voornaam, string adres, string telefoonnumer, string authorityNaam, DateTime geboortedatum, string email, string wachtwoord) {
        //    this.Naam = naam;
        //    this.Voornaam = voornaam;
        //    this.Adres = adres;
        //    this.Telefoonnummer = telefoonnumer;
        //    this.AuthorityNaam = authorityNaam;
        //    this.Geboortedatum = geboortedatum;
        //    this.Email = email;
        //    this.Wachtwoord = wachtwoord;
        //}
        #endregion

        #region Methods

        public void EditGebruiker(string email,string naam, string voornaam, string telefoonnummer, DateTime geboortedatum) {
            Email = email;
            Naam = naam;
            Voornaam = voornaam;
            Telefoonnummer = telefoonnummer;
            Geboortedatum = geboortedatum;
        }

        #endregion
    }
}
