using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain
{
    public abstract class Gebruiker
    {

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
        public string Naam
        {
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
                    throw new ArgumentException("Voornaam mag niet leeg zijn");
                if (value.Length > 50)
                    throw new ArgumentException("Voornaam mag niet langer zijn dan 50 tekens");
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
                string pattern = "[0,4|5]{2}[0-9]{7,8}";
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

             if(value > DateTime.Today)
                {
                    throw new ArgumentException("De Geboortedag kan niet in de toekomst liggen");
                }
                _geboortedatum = value;

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
                    throw new ArgumentException("Opgegeven e-mail is geen correct e-mailadres");
                }
            }
        }
        public int Graad { get; set; }

        public ICollection<GebruikerGraad> Graden { get; set; }

        //uncomment if needed
        public DateTime InschrijvingsDatum { get; set; }
        public string Straatnaam { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Stad { get; set; }
        public string Land { get; set; }
        public string Rijksregisternummer { get; set; }
        public string Gsm { get; set; }
        public string EmailOuders { get; set; }
        public string Geboorteplek { get; set; }
        #endregion

        //nodig voor het aanmaken van een nieuwe gebruiker
        #region Constructors
        protected Gebruiker()
        {

        }

        #endregion

        #region Methods

        public void EditGebruiker(string email, string naam, string voornaam, string telefoonnummer, DateTime geboortedatum, string adres)
        {
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
