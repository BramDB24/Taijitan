using G07_Taijitan.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace G07_Taijitan.Tests.Data {
    public class DummyApplicationDbContext {
        private readonly Gebruiker _gebruiker1;
        public Gebruiker _gebruiker2 { get; }

        public IEnumerable<Gebruiker> Gebruikers => new List<Gebruiker> {_gebruiker1, _gebruiker2 };
        

        public DummyApplicationDbContext() {

            

            _gebruiker1 = new Gebruiker()
            {
                Naam = "De Smet",
                Voornaam = "Jonah",
                Adres = "Adres 123",
                Email = "debleecker.b@gmail.com",
                Geboortedatum = new DateTime(1984, 2, 13),
                Gebruikersnaam = "jonah.desmet",
                Telefoonnummer = "0476000999",
                AuthorityNaam = "Admin",
                Wachtwoord = "P@ssword1",
                Graad = 3
            };
            _gebruiker2 = new Gebruiker
            {
                Naam = "De Bleecker",
                Voornaam = "Bram",
                Adres = "Adres 777",
                Email = "debleecker.b@gmail.com",
                Geboortedatum = new DateTime(1999, 12, 24),
                Gebruikersnaam = "bram.debleecker",
                Telefoonnummer = "0476000002",
                AuthorityNaam = "Gebruiker",
                Wachtwoord = "P@ssword2",
                Graad = 1
            };
        }
    }
}
