﻿using G07_Taijitan.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.LesMateriaal;

namespace G07_Taijitan.Data {
    public class GebruikerDataInitializer {
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public GebruikerDataInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager) {
            _context = context;
            _userManager = userManager;
        }

        public async Task InitializeData() {
            _context.Database.EnsureDeleted();
            if(_context.Database.EnsureCreated()) {
                if(!_context.Gebruikers.Any()) {
                    ////gebruikers
                    //Gebruiker gebruiker1 = new Gebruiker("De Smet", "Jonah", "EenAdres", "0476000000", "Lid", new DateTime(1998, 03, 13), "jonah.desmet@test.com", "jonah");
                    //Gebruiker gebruiker2 = new Gebruiker("Scheirlinckx", "Lowie", "EenAdresLowie", "0476000001", "LesGever", new DateTime(1998, 02, 12), "lowie.scheirlinckx@test.com", "lowie");
                    //Gebruiker gebruiker3 = new Gebruiker("De Bleecker", "Bram", "EenAdresBram", "0476000002", "Beheerder", new DateTime(1998, 01, 11), "bram.debleecker@test.com", "bram");
                    //Gebruiker gebruiker4 = new Gebruiker("De Bruycker", "Johanna", "EenAdresJohanna", "0476000003", "Lid", new DateTime(1998, 04, 10), "johanna.debruycker@test.com", "johanna");

                    Gebruiker testUser = new Lid() {
                        Naam = "De Smet",
                        Voornaam = "Jonah",
                        Adres = "EenAdres",
                        Email = "jonah.desmet@hotmail.com",
                        Geboortedatum = new DateTime(1998, 03, 13),
                        Gebruikersnaam = "jonah.desmet",
                        Telefoonnummer = "054000000",
                        Wachtwoord = "P@ssword1",
                        Graad = Graad.Dan3,
                        InschrijvingsDatum = DateTime.Today,
                        Straatnaam = "straat",
                        Huisnummer = "1",
                        Postcode = "9506",
                        Stad = "stad",
                        Land = "België",
                        Rijksregisternummer = "19980313000000",
                        Gsm = "0476000000",
                        EmailOuders = "ouders@hotmail.com",
                        Geboorteplek = "Aalst"

                    };

                    Lesmateriaal lesmateriaal = new Video() {
                        Naam = "Test",
                        Url = "https://www.youtube.com/embed/AQY814Q--Hs"
                    };
                    Lesmateriaal vid2 = new Video() {
                        Naam = "Video2",
                        Url = "https://www.youtube.com/watch?v=jkbYYnGOeb8"
                    };

                    Oefening oefening1 = new Oefening() {
                        Naam = "oefeningTestMetVid",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Beenworpen,
                        Lesmateriaal = new List<Lesmateriaal> {lesmateriaal}
                    };

                    Oefening oefening2 = new Oefening() {
                        Naam = "OefeningTest2",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Armstoten,
                        Lesmateriaal = new List<Lesmateriaal> {vid2}
                    };

                    Oefening oefening3 = new Oefening() {
                        Naam = "OefeningTest3",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Armstoten,
                        Lesmateriaal = new List<Lesmateriaal> {}

                    };
                    Oefening oefening4 = new Oefening() {
                        Naam = "OefeningTest4",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Armstoten,
                        Lesmateriaal = new List<Lesmateriaal> {}
                    };
                    Oefening oefening5 = new Oefening()
                    {
                        Naam = "OefeningTest5",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Kopstoten,
                        Lesmateriaal = new List<Lesmateriaal> {}
                    };
                    
                    _context.Oefeningen.AddRange(oefening1, oefening2, oefening3, oefening4);

                    await InitilizeUsers(testUser.Gebruikersnaam, testUser.Wachtwoord, testUser.GetType().Name);

                    _context.Gebruikers.Add(testUser);
                    _context.SaveChanges();
                }
            }
        }

        private async Task InitilizeUsers(string username, string password, string role) {
            var user = new IdentityUser { UserName = username};
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
        }
    }
}
