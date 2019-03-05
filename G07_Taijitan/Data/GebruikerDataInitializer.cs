using G07_Taijitan.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace G07_Taijitan.Data
{
    public class GebruikerDataInitializer
    {
        /* change at 2402 databank seeding aangepast, prop instead of ctor, initializeuser methode voor gebruiker die kan aanmelden gedefined */
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
                //_context.SaveChanges();
                if (!_context.gebruikers.Any())
                {
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
                        Graad = 1,
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

                    //Graad kyu1 = new Graad()
                    //{
                    //    Naam = "Ichi-kyu",
                    //    GraadNiveau = 1
                    //};

                    //Graad kyu2 = new Graad()
                    //{
                    //    Naam = "Ni-kyu",
                    //    GraadNiveau = 2
                    //};

                    //Graad dan1 = new Graad()
                    //{
                    //    Naam = ""
                    //};

                    //Gebruiker testUser2 = new Lid() {
                    //    Naam = "De Bleecker",
                    //    Voornaam = "Bram",
                    //    Adres = "Adress",
                    //    Email = "debleecker.b@gmail.com",
                    //    Geboortedatum = new DateTime(1999, 12, 24),
                    //    Gebruikersnaam = "bram.debleecker",
                    //    Telefoonnummer = "0478124578",                        
                    //    Wachtwoord = "P@ssword2",
                    //    Graad = 1
                    //};
                    await InitilizeUsers(testUser.Gebruikersnaam, testUser.Wachtwoord, testUser.GetType().Name);
                   // await InitilizeUsers(testUser2.Gebruikersnaam, testUser2.Wachtwoord, testUser2.GetType().Name);
                    
                    _context.gebruikers.Add(testUser);
                   // _context.gebruikers.Add(testUser2);

                    //Gebruiker[] gebruikers = { gebruiker1, gebruiker2, gebruiker3, gebruiker4 };
                    //_context.gebruikers.AddRange(gebruikers);
                    _context.SaveChanges();

                }
            }
        }

        private async Task InitilizeUsers(string username, /*string email,*/ string password, string role)
        {   
            var user = new IdentityUser { UserName = username/*, Email = email */};
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
        }
    }
}
