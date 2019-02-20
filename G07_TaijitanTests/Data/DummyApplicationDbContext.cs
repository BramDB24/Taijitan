using G07_Taijitan.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace G07_Taijitan.Tests.Data {
    public class DummyApplicationDbContext {
        private readonly Gebruiker _gebruiker1;


        public IEnumerable<Gebruiker> Gebruikers => new List<Gebruiker> { Bram, _gebruiker1 };
        public Gebruiker Bram { get; }

        public DummyApplicationDbContext() {
            Bram = new Gebruiker("debleecker", "bram", "staat", "0477112233", "admin", new DateTime(1999, 24, 12));
            _gebruiker1 = new Gebruiker("naam", "voornaam", "straat", "1234567890", "lid", new DateTime(2000, 1, 1));



        }
    }
}
