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
                await InitilizeUsers();
                //_context.SaveChanges();
                if (!_context.gebruikers.Any())
                {
                    ////gebruikers
                    //Gebruiker gebruiker1 = new Gebruiker("De Smet", "Jonah", "EenAdres", "0476000000", "Lid", new DateTime(1998, 03, 13), "jonah.desmet@test.com", "jonah");
                    //Gebruiker gebruiker2 = new Gebruiker("Scheirlinckx", "Lowie", "EenAdresLowie", "0476000001", "LesGever", new DateTime(1998, 02, 12), "lowie.scheirlinckx@test.com", "lowie");
                    //Gebruiker gebruiker3 = new Gebruiker("De Bleecker", "Bram", "EenAdresBram", "0476000002", "Beheerder", new DateTime(1998, 01, 11), "bram.debleecker@test.com", "bram");
                    //Gebruiker gebruiker4 = new Gebruiker("De Bruycker", "Johanna", "EenAdresJohanna", "0476000003", "Lid", new DateTime(1998, 04, 10), "johanna.debruycker@test.com", "johanna");

                    Gebruiker testUser = new Gebruiker() {
                        Naam = "De Smet",
                        Voornaam = "Jonah",
                        Adres = "EenAdres",
                        Email = "jonah.desmet@hotmail.com",
                        Geboortedatum = new DateTime(1998, 03, 13),
                        Gebruikersnaam = "jonah.desmet",
                        Telefoonnummer = "0476000000",
                        AuthorityNaam = "Lid",
                        Wachtwoord = "password",
                        Graad = 1
                    };

                    _context.gebruikers.Add(testUser);

                    //Gebruiker[] gebruikers = { gebruiker1, gebruiker2, gebruiker3, gebruiker4 };
                    //_context.gebruikers.AddRange(gebruikers);
                    _context.SaveChanges();

                }
            }

        }

        private async Task InitilizeUsers()
        {
            string email = "jonah.desmet@hotmail.com";
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, "P@ssword1");
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Gebruiker"));
        }
    }
}
