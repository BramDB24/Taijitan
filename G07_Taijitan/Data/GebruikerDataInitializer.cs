using G07_Taijitan.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Data
{
    public class GebruikerDataInitializer
    {
        private readonly ApplicationDbContext _context;

        public GebruikerDataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializeData()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            if (!_context.gebruikers.Any())
            {
                //gebruikers
                Gebruiker gebruiker1 = new Gebruiker("De Smet", "Jonah", "EenAdres", "0476000000", "Lid", new DateTime(1998,03,13));
                Gebruiker gebruiker2 = new Gebruiker("Scheirlinckx", "Lowie", "EenAdresLowie", "0476000001", "LesGever", new DateTime(1998,02,12));
                Gebruiker gebruiker3 = new Gebruiker("De Bleecker", "Bram", "EenAdresBram", "0476000002", "Beheerder", new DateTime(1998,01,11));
                Gebruiker gebruiker4 = new Gebruiker("De Bruycker", "Johanna", "EenAdresJohanna", "0476000003", "Lid", new DateTime(1998,04,10));

                Gebruiker[] gebruikers = { gebruiker1, gebruiker2, gebruiker3, gebruiker4 };
                _context.gebruikers.AddRange(gebruikers);
                _context.SaveChanges();

            }
        }
    }
}
