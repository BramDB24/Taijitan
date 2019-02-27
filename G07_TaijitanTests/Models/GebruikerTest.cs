using G07_Taijitan.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace G07_Taijitan.Tests.Models {

    public class GebruikerTest {
        private const string _gebruikersnaam = "bram.debleecker";
        private const string _naam = "De Bleecker";
        private const string _voornaam = "Bram";
        private const string _adres = "Adres 777";
        private const string _email = "debleecker.b@gmail.com";
        private const string _telefoonnummer = "0476000002";
        private const string _authorityNaam = "Gebruiker";
        private const string _wachtwoord = "p@ssword2";
        private readonly DateTime _geboorteDatum = new DateTime(1999, 12, 24);
        private const int _graad = 1;

        #region Constructors
        [Fact]
        public void NewGebruiker_EmptyData_CreateGebruiker()
        {
            var gebruiker = new Gebruiker();
            Assert.Null(gebruiker.Gebruikersnaam);
            Assert.Null(gebruiker.Naam);
            Assert.Null(gebruiker.Voornaam);
            Assert.Null(gebruiker.Adres);
            Assert.Null(gebruiker.Email);
            Assert.Null(gebruiker.Telefoonnummer);
            Assert.Null(gebruiker.AuthorityNaam);
            Assert.Null(gebruiker.Wachtwoord);
            Assert.Equal(new DateTime(), gebruiker.Geboortedatum);
            Assert.Equal(0, gebruiker.Graad);
        }
        [Fact]
        public void NewGebruiker_ValidData_CreateGebruiker() //Overbodig?
        {
            var gebruiker = new Gebruiker()
            {
                Naam = _naam,
                Voornaam = _voornaam,
                Adres = _adres,
                Email = _email,
                Geboortedatum = _geboorteDatum,
                Gebruikersnaam = _gebruikersnaam,
                Telefoonnummer = _telefoonnummer,
                AuthorityNaam = _authorityNaam,
                Wachtwoord = _wachtwoord,
                Graad = _graad
            }; ;
            Assert.Equal(_naam, gebruiker.Naam);
            Assert.Equal(_voornaam, gebruiker.Voornaam);
            Assert.Equal(_adres, gebruiker.Adres);
            Assert.Equal(_email, gebruiker.Email);
            Assert.Equal(_geboorteDatum, gebruiker.Geboortedatum);
            Assert.Equal(_gebruikersnaam, gebruiker.Gebruikersnaam);
            Assert.Equal(_telefoonnummer, gebruiker.Telefoonnummer);
            Assert.Equal(_authorityNaam, gebruiker.AuthorityNaam);
            Assert.Equal(_wachtwoord, gebruiker.Wachtwoord);
            Assert.Equal(_graad, gebruiker.Graad);
        }
        #endregion

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //[InlineData("123456789")]
        //public void NewGebruiker_NaamOrVoornaamOrAdressNotValid_ThrowsArgumentException(string tekens)
        //{
        //    Assert.Throws<ArgumentException>(() => new Gebruiker()
        //    {
        //        Naam = tekens,
        //        Voornaam = _voornaam,
        //        Adres = _adres,
        //        Email = _email,
        //        Geboortedatum = _geboorteDatum,
        //        Gebruikersnaam = _gebruikersnaam,
        //        Telefoonnummer = _telefoonnummer,
        //        AuthorityNaam = _authorityNaam,
        //        Wachtwoord = _wachtwoord,
        //        Graad = _graad
        //    });
        //    Assert.Throws<ArgumentException>(() => new Gebruiker()
        //    {
        //        Naam = _naam,
        //        Voornaam = tekens,
        //        Adres = _adres,
        //        Email = _email,
        //        Geboortedatum = _geboorteDatum,
        //        Gebruikersnaam = _gebruikersnaam,
        //        Telefoonnummer = _telefoonnummer,
        //        AuthorityNaam = _authorityNaam,
        //        Wachtwoord = _wachtwoord,
        //        Graad = _graad
        //    });
        //    Assert.Throws<ArgumentException>(() => new Gebruiker()
        //    {
        //        Naam = _naam,
        //        Voornaam = _voornaam,
        //        Adres = tekens,
        //        Email = _email,
        //        Geboortedatum = _geboorteDatum,
        //        Gebruikersnaam = _gebruikersnaam,
        //        Telefoonnummer = _telefoonnummer,
        //        AuthorityNaam = _authorityNaam,
        //        Wachtwoord = _wachtwoord,
        //        Graad = _graad
        //    });
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //[InlineData("abcdefghij")]
        //[InlineData("abcfef1213fev")]
        //public void NewGebruiker_TelefoonNummerNotValid_ThrowsArgumentException(string telefoonNummer)
        //{
        //    Assert.Throws<ArgumentException>(() => Assert.Throws<ArgumentException>(() => new Gebruiker()
        //    {
        //        Naam = _naam,
        //        Voornaam = _voornaam,
        //        Adres = _adres,
        //        Email = _email,
        //        Geboortedatum = _geboorteDatum,
        //        Gebruikersnaam = _gebruikersnaam,
        //        Telefoonnummer = telefoonNummer,
        //        AuthorityNaam = _authorityNaam,
        //        Wachtwoord = _wachtwoord,
        //        Graad = _graad
        //    }));
        //}

        
    }
}
