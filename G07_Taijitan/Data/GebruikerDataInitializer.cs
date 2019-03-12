using G07_Taijitan.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.LesMateriaal;

namespace G07_Taijitan.Data
{
    public class GebruikerDataInitializer
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public GebruikerDataInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                if (!_context.Gebruikers.Any())
                {
                    ////Gebruikers
                    Gebruiker Jonah = new Lid()
                    {
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
                    Gebruiker Bram = new Lid()
                    {
                        Naam = "De Bleecker",
                        Voornaam = "Bram",
                        Adres = "EenAdres1",
                        Email = "bram.debleccker@hotmail.com",
                        Geboortedatum = new DateTime(1999, 02, 12),
                        Gebruikersnaam = "bram.debleecker",
                        Telefoonnummer = "054111111",
                        Wachtwoord = "P@ssword2",
                        Graad = Graad.Kyu4,
                        InschrijvingsDatum = DateTime.Today,
                        Straatnaam = "straat2",
                        Huisnummer = "2",
                        Postcode = "9500",
                        Stad = "stad1",
                        Land = "België",
                        Rijksregisternummer = "19990212000000",
                        Gsm = "0476000001",
                        EmailOuders = "ouders@hotmail.com",
                        Geboorteplek = "Aalst"
                    };
                    Gebruiker Johanna = new Lid()
                    {
                        Naam = "De Bruycker",
                        Voornaam = "Johanna",
                        Adres = "EenAdres",
                        Email = "johanna.debruycker@hotmail.com",
                        Geboortedatum = new DateTime(1997, 01, 11),
                        Gebruikersnaam = "johanna.debruycker",
                        Telefoonnummer = "054000001",
                        Wachtwoord = "P@ssword3",
                        Graad = Graad.Dan8,
                        InschrijvingsDatum = DateTime.Today,
                        Straatnaam = "straat",
                        Huisnummer = "1",
                        Postcode = "9500",
                        Stad = "stad",
                        Land = "België",
                        Rijksregisternummer = "19970111000000",
                        Gsm = "0476000002",
                        EmailOuders = "ouders@hotmail.com",
                        Geboorteplek = "Aalst"
                    };
                    Gebruiker Lowie = new Lid()
                    {
                        Naam = "Scheirlinckx",
                        Voornaam = "Lowie",
                        Adres = "EenAdres2",
                        Email = "lowie.scheirlinckx@hotmail.com",
                        Geboortedatum = new DateTime(1998, 12, 10),
                        Gebruikersnaam = "lowie.scheirlinckx",
                        Telefoonnummer = "054000002",
                        Wachtwoord = "P@ssword4",
                        Graad = Graad.Dan6,
                        InschrijvingsDatum = DateTime.Today,
                        Straatnaam = "straat",
                        Huisnummer = "1",
                        Postcode = "9506",
                        Stad = "stad",
                        Land = "België",
                        Rijksregisternummer = "19981210000000",
                        Gsm = "0476000002",
                        EmailOuders = "ouders@hotmail.com",
                        Geboorteplek = "Aalst"
                    };

                    ////LesMateriaal
                    #region WurgGrepenVideo
                    //Wurggrepen Kyu1 - Dan3
                    Lesmateriaal WurgGreep1 = new Video()
                    {
                        Naam = "WurgGreepKyu1",
                        Url = "https://www.youtube.com/embed/2s53EtXPJd8"
                    };
                    Lesmateriaal WurgGreep2 = new Video()
                    {
                        Naam = "WurgGreep1Kyu1",
                        Url = "https://www.youtube.com/embed/Gf4H1EBFE7o"
                    };

                    Lesmateriaal WurgGreep3 = new Video()
                    {
                        Naam = "WurgGreepDan3",
                        Url = "https://www.youtube.com/embed/GaD5s0_H0T4"
                    };

                    Lesmateriaal WurgGreep4 = new Video()
                    {
                        Naam = "WurgGreep1Dan3",
                        Url = "https://www.youtube.com/embed/LppnEfRoFIM"
                    };

                    #endregion

                    #region BeenWorpenVideo
                    Lesmateriaal lesmateriaal1 = new Video()
                    {
                        Naam = "BeenworpKyu1",
                        Url = "https://www.youtube.com/embed/JdGWiOcijdQ"
                    };
                    Lesmateriaal lesmateriaal2 = new Video()
                    {
                        Naam = "BeenworpKyu1",
                        Url = "https://www.youtube.com/embed/71XFjhqKBIY"
                    };
                    Lesmateriaal lesmateriaal3 = new Video()
                    {
                        Naam = "BeenworpDan3",
                        Url = "https://www.youtube.com/embed/CrwGeAMbAUQ"
                    };
                    Lesmateriaal lesmateriaal4 = new Video()
                    {
                        Naam = "BeenworpDan4",
                        Url = "https://www.youtube.com/embed/RN6jkQ4dAbo"
                    };
                    #endregion

                    #region ArmStotenVideo
                    Lesmateriaal Armstoot = new Video()
                    {
                        Naam = "ArmstootKyu1",
                        Url = "https://www.youtube.com/embed/udo0RzY-9Cg"
                    };
                    Lesmateriaal Armstoot1 = new Video()
                    {
                        Naam = "Armstoot1Kyu1",
                        Url = "https://www.youtube.com/embed/udo0RzY-9Cg"
                    };
                    Lesmateriaal Armstoot2 = new Video()
                    {
                        Naam = "ArmstootDan3",
                        Url = "https://www.youtube.com/embed/udo0RzY-9Cg"
                    };
                    Lesmateriaal Armstoot3 = new Video()
                    {
                        Naam = "Armstoot1Dan3",
                        Url = "https://www.youtube.com/embed/udo0RzY-9Cg"
                    };
                    #endregion

                    #region KopStotenVideo
                    Lesmateriaal Kopstoot = new Video()
                    {
                        Naam = "KopstootKyu1",
                        Url = "https://www.youtube.com/embed/-qjnHJHy8Og"
                    };
                    Lesmateriaal Kopstoot1 = new Video()
                    {
                        Naam = "Kopstoot1Kyu1",
                        Url = "https://www.youtube.com/embed/rHBpNOpzths"
                    };
                    Lesmateriaal Kopstoot2 = new Video()
                    {
                        Naam = "KopstootDan3",
                        Url = "https://www.youtube.com/embed/3Qma7Sxe6VE"
                    };
                    Lesmateriaal Kopstoot3 = new Video()
                    {
                        Naam = "Kopstoot1Dan3",
                        Url = "https://www.youtube.com/embed/t7HYNINWJe0"
                    };
                    #endregion
                    
                    ////Oefeningen
                    #region Beenworpen

                    //Beenworpen - Kyu1
                    Oefening oefening1 = new Oefening()
                    {
                        Naam = "DummyOefening_Beenworp_Kyu1",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Beenworpen,
                        Lesmateriaal = new List<Lesmateriaal> { lesmateriaal1 }
                    };

                    Oefening oefening6 = new Oefening()
                    {
                        Naam = "DummyOefening1_Beenworp_Kyu1",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Beenworpen,
                        Lesmateriaal = new List<Lesmateriaal> { lesmateriaal2 }
                    };

                    //Beenworpen - Dan3
                    Oefening oefening7 = new Oefening()
                    {
                        Naam = "DummyOefening_Beenworp_Dan3",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Beenworpen,
                        Lesmateriaal = new List<Lesmateriaal> { lesmateriaal3 }
                    };

                    Oefening oefening8 = new Oefening()
                    {
                        Naam = "DummyOefening1_Beenworp_Dan3",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Beenworpen,
                        Lesmateriaal = new List<Lesmateriaal> { lesmateriaal4 }
                    };
                    #endregion

                    #region Armstoten
                    //Armstoten - Kyu1
                    Oefening oefening2 = new Oefening()
                    {
                        Naam = "DummyOefening_Armstoot_Kyu1",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Armstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Armstoot }
                    };

                    Oefening oefening3 = new Oefening()
                    {
                        Naam = "DummyOefening1_Armstoot_Kyu1",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Armstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Armstoot1 }
                    };

                    //Armstoten - Dan3
                    Oefening oefening9 = new Oefening()
                    {
                        Naam = "DummyOefening_Armstoot_Dan3",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Armstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Armstoot2 }
                    };

                    Oefening oefening10 = new Oefening()
                    {
                        Naam = "DummyOefening1_Armstoot_Dan3",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Armstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Armstoot3 }
                    };
                    #endregion

                    #region WurgGrepen
                    //Wurggrepen - Kyu1
                    Oefening oefening4 = new Oefening()
                    {
                        Naam = "DummyOefening_WurgGreep_Kyu1",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Wurggrepen,
                        Lesmateriaal = new List<Lesmateriaal> { WurgGreep1 }
                    };

                    Oefening oefening11 = new Oefening()
                    {
                        Naam = "DummyOefening1_WurgGreep_Kyu1",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Wurggrepen,
                        Lesmateriaal = new List<Lesmateriaal> { WurgGreep2 }
                    };

                    //Wurggrepen - Dan3
                    Oefening oefening12 = new Oefening()
                    {
                        Naam = "DummyOefening_WurgGreep_Dan3",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Wurggrepen,
                        Lesmateriaal = new List<Lesmateriaal> { WurgGreep3 }
                    };

                    Oefening oefening13 = new Oefening()
                    {
                        Naam = "DummyOefening1_WurgGreep_Dan3",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Wurggrepen,
                        Lesmateriaal = new List<Lesmateriaal> { WurgGreep4 }
                    };
                    #endregion

                    #region Kopstoten
                    //Kopstoten - Kyu1
                    Oefening oefening14 = new Oefening()
                    {
                        Naam = "DummyOefening_Kopstoot_Kyu1",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Kopstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Kopstoot }
                    };

                    Oefening oefening5 = new Oefening()
                    {
                        Naam = "DummyOefening1_Kopstoot_Kyu1",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Kopstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Kopstoot1 }
                    };

                    //kopstoten - Dan3
                    Oefening oefening15 = new Oefening()
                    {
                        Naam = "DummyOefening_Kopstoot_Dan3",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Kopstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Kopstoot2 }
                    };

                    Oefening oefening16 = new Oefening()
                    {
                        Naam = "DummyOefening1_Kopstoot_Dan3",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Kopstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Kopstoot3 }
                    };
                    #endregion

                    _context.Oefeningen.AddRange(
                        oefening1, oefening2, oefening3, oefening4,
                        oefening5, oefening6, oefening7, oefening8,
                        oefening9, oefening10, oefening11, oefening12,
                        oefening13, oefening14, oefening15
                        );

                    await InitilizeUsers(Jonah.Gebruikersnaam, Jonah.Wachtwoord, Jonah.GetType().Name);
                    await InitilizeUsers(Bram.Gebruikersnaam, Bram.Wachtwoord, Bram.GetType().Name);
                    await InitilizeUsers(Johanna.Gebruikersnaam, Johanna.Wachtwoord, Johanna.GetType().Name);
                    await InitilizeUsers(Lowie.Gebruikersnaam, Lowie.Wachtwoord, Lowie.GetType().Name);


                    _context.Gebruikers.AddRange(Jonah, Bram, Lowie, Johanna);
                    _context.SaveChanges();
                }
            }
        }

        private async Task InitilizeUsers(string username, string password, string role)
        {
            var user = new IdentityUser { UserName = username };
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
        }
    }
}
