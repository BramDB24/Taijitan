using G07_Taijitan.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace G07_Taijitan.Tests.Data {
    public class DummyApplicationDbContext {
        private readonly Gebruiker _gebruiker1;
        public Gebruiker _gebruiker2 { get; }

        public Gebruiker _gebruiker3 { get; }

        public IEnumerable<Gebruiker> Gebruikers => new List<Gebruiker> {_gebruiker1, _gebruiker2 };
        

        public DummyApplicationDbContext() {

            _gebruiker1 = new Gebruiker
            {
                Gebruikersnaam = "Scheirlinckx",
                Naam = "Lowie",
                Adres = "Adres 123",
                Email = "Lowiescheirlinckx@hotmail.com",
                Telefoonnummer = "054999999",
                Geboortedatum = new DateTime(1998, 9, 26),
                Graad = 2
            };

            _gebruiker2 = new Gebruiker
            {
                Gebruikersnaam = "De Smet",
                Naam = "Jonah",
                Adres = "Adres 555",
                Email = "Jonah@skynet.be",
                Telefoonnummer = "054666666",
                Geboortedatum = new DateTime(1992, 5, 12),
                Graad = 1
            };

            _gebruiker3 = new Gebruiker
            {
                Gebruikersnaam = "De Bruycker",
                Naam = "Johanna",
                Adres = "Adres 984",
                Email = "johanna@telenet.be",
                Telefoonnummer = "0485974525",
                Geboortedatum = new DateTime(1997, 7, 8),
                Graad = 2
            };
        }
    }
}
