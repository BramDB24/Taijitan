using G07_Taijitan.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace G07_Taijitan.Tests.Data {
    public class DummyApplicationDbContext {
        public Gebruiker _gebruiker1 { get; }
        public Gebruiker _gebruiker2 { get; }

        public Gebruiker _gebruiker3 { get; }

        public IEnumerable<Gebruiker> Gebruikers => new List<Gebruiker> {_gebruiker1, _gebruiker2 };
        

        public DummyApplicationDbContext() {

            

            _gebruiker1 = new Lid()
            {
                Naam = "De Smet",
                Voornaam = "Jonah",
                Adres = "Adres 123",
                Email = "jonah.desmet@hotmail.com",
                Geboortedatum = new DateTime(1984, 2, 13),
                Gebruikersnaam = "jonah.desmet",
                Telefoonnummer = "0478001144",                
                Wachtwoord = "P@ssword1",
                Graad = 3
            };
            //_gebruiker2 = new Lesgever
            //{
            //    Naam = "De Bleecker",
            //    Voornaam = "Bram",
            //    Adres = "Adres 777",
            //    Email = "debleecker.b@gmail.com",
            //    Geboortedatum = new DateTime(1999, 12, 24),
            //    Gebruikersnaam = "bram.debleecker",
            //    Telefoonnummer = "0476000002",            
            //    Wachtwoord = "P@ssword2",
            //    Graad = 1
            //};

            //_gebruiker3 = new Beheerder
            //{
            //    Gebruikersnaam = "De Bruycker",
            //    Naam = "Johanna",
            //    Adres = "Adres 984",
            //    Email = "johanna@telenet.be",
            //    Telefoonnummer = "0485974525",
            //    Geboortedatum = new DateTime(1997, 7, 8),
            //    Graad = 2
            //};
        }
    }
}
