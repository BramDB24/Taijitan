using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain
{
    public abstract class Gebruiker
    {
        /* change at 2402 dropped ctor, util van prop */
        #region Fields
        private string _naam;
        private string _voornaam;
        private string _adres;
        private string _telefoonnummer;
        private DateTime _geboortedatum;
        private string _email;


        #endregion

        #region Properties

        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Naam {
            get
            {
                return _naam;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Naam mag niet leeg zijn");
                if (value.Length > 50)
                    throw new ArgumentException("Naam mag niet langer zijn dan 50 tekens");
                _naam = value;
            }
        }

        public string Voornaam
        {
            get
            {
                return _voornaam;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Naam mag niet leeg zijn");
                if (value.Length > 50)
                    throw new ArgumentException("Naam mag niet langer zijn dan 50 tekens");
                _voornaam = value;
            }
        }
        public string Adres
        {
            get
            {
                return _adres;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Adres mag niet leeg zijn");
                if (value.Length > 100)
                    throw new ArgumentException("Adres mag niet langer zijn dan 100 tekens");
                _adres = value;
            }
        }
        public string Telefoonnummer
        {
            get
            {
                return _telefoonnummer;
            }
            set
            {
                string pattern = "[0, 4 | 5]{ 2}[0-9]{ 7,8}"; 
                if (Regex.IsMatch(value, pattern))
                {
                    _telefoonnummer = value;
                }
                else
                {
                    throw new ArgumentException("Telefoonnumer is niet correct");
                }
                
            }
        }
        public DateTime Geboortedatum
        {
            get
            {
                return _geboortedatum;
            }
            set
            {

                try
                {
                    if (value > DateTime.Today)
                        throw new ArgumentException("Geboortedatum kan niet in de toekomst liggen");
                    _geboortedatum = value;
                } catch (Exception e)
                {
                    throw new ArgumentException("Geboortedatum is niet correct");
                }
                
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email mag niet leeg zijn");
                if (value.Length > 150)
                    throw new ArgumentException("Email mag niet langer zijn dan 150 tekens");
                string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$";
                if (Regex.IsMatch(value, pattern))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Email is niet correct");
                }
            }
        }
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

        public void EditGebruiker(string email,string naam, string voornaam, string telefoonnummer, DateTime geboortedatum, string adres) {
            Email = email;
            Naam = naam;
            Voornaam = voornaam;
            Telefoonnummer = telefoonnummer;
            Geboortedatum = geboortedatum;
            Adres = adres;
        }

        #endregion
    }
}
