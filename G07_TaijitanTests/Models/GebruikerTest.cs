using G07_Taijitan.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace G07_Taijitan.Tests.Models {

    public class GebruikerTest {               
        private const string _name = "De Bleecker";
        private const string _voornaam = "Bram";
        private const string _adres = "straatnaam";
        private const string _telefoonnummer = "0477112233";
        private const string _authorityNaam = "admin";
        private readonly DateTime _geboorteDatum = new DateTime(1999, 24, 12);


        #region Constructors
        [Fact]
        public void NewGebruiker_ValidData_CreateGebruiker() {
            var gebruiker = new Gebruiker(_name, _voornaam, _adres, _telefoonnummer, _authorityNaam, _geboorteDatum);            
            Assert.Equal(_name, gebruiker.Naam);
            Assert.Equal(_voornaam, gebruiker.Voornaam);
            Assert.Equal(_adres, gebruiker.Adres);
            Assert.Equal(_telefoonnummer, gebruiker.Telefoonnummer);
            Assert.Equal(_authorityNaam, gebruiker.AuthorityNaam);
            Assert.Equal(_geboorteDatum, gebruiker.Geboortedatum);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("123456789")]
        public void NewGebruiker_NaamOrVoornaamOrAdressNotValid_ThrowsArgumentException(string tekens) {
            Assert.Throws<ArgumentException>(() => new Gebruiker(tekens, _voornaam, _adres, _telefoonnummer, _authorityNaam, _geboorteDatum));
            Assert.Throws<ArgumentException>(() => new Gebruiker(_name, tekens, _adres, _telefoonnummer, _authorityNaam, _geboorteDatum));
            Assert.Throws<ArgumentException>(() => new Gebruiker(_name, _voornaam, tekens, _telefoonnummer, _authorityNaam, _geboorteDatum));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("abcdefghij")]
        [InlineData("abcfef1213fev")]
        public void NewGebruiker_TelefoonNummerNotValid_ThrowsArgumentException(string telefoonNummer) {
            Assert.Throws<ArgumentException>(() => new Gebruiker(_name, _voornaam, _adres, telefoonNummer, _authorityNaam, _geboorteDatum));
        }

        #endregion
    }
}
