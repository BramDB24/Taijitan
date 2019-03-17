using G07_Taijitan.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.LesMateriaal;

namespace G07_Taijitan.Tests.Data {
    public class DummyApplicationDbContext {

        private readonly IEnumerable<Lesmateriaal> _lesmateriaal1;
        private readonly IEnumerable<Lesmateriaal> _lesmateriaal2;


        public Gebruiker _gebruiker1 { get; }
        public Gebruiker _gebruiker2 { get; }
        public IEnumerable<Gebruiker> Gebruikers => new List<Gebruiker> { _gebruiker1, _gebruiker2 };
        public Oefening _oefening1 { get; }
        public Oefening _oefening2 { get; }
        public IEnumerable<Oefening> Oefeningen => new List<Oefening> { _oefening1, _oefening2 };
        
        public DummyApplicationDbContext() {



            _gebruiker1 = new Lid() {
                Naam = "De Smet",
                Voornaam = "Jonah",
                Adres = "Adres 123",
                Email = "jonah.desmet@hotmail.com",
                Geboortedatum = new DateTime(1984, 2, 13),
                Gebruikersnaam = "jonah.desmet",
                Telefoonnummer = "0478001144", 
                Wachtwoord = "P@ssword1",
                Graad = Graad.Kyu4
            };
            _gebruiker2 = new Lesgever {
                Naam = "De Bleecker",
                Voornaam = "Bram",
                Adres = "Adres 777",
                Email = "debleecker.b@gmail.com",
                Geboortedatum = new DateTime(1999, 12, 24),
                Gebruikersnaam = "bram.debleecker",
                Telefoonnummer = "0476000002",
                Wachtwoord = "P@ssword2",
                Graad = Graad.Kyu6
            };

            _lesmateriaal1 = new List<Lesmateriaal>() {
                new Foto { Naam = "foto1"}, new Video {Naam = "video1"}, new Tekst {Naam = "tekst1"}
            };

            _lesmateriaal2 = new List<Lesmateriaal>() {
                new Tekst {Naam = "slaan" }, new Foto {Naam = "slagfoto"}, new Video {Naam = "slagvideo"}
            };

            _oefening1 = new Oefening {
                Naam = "Vallen",
                OefeningType = OefeningType.Beenworpen,
                Lesmateriaal = _lesmateriaal1
            };

            _oefening2 = new Oefening {
                Naam = "slaan",
                OefeningType = OefeningType.Armstoten,
                Lesmateriaal = _lesmateriaal2
            };
        }
    }
}
