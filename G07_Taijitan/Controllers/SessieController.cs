using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Filters;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.RepoInterface;
using Microsoft.AspNetCore.Mvc;

namespace G07_Taijitan.Controllers
{
    public class SessieController : Controller
    {
        private IGebruikerRepository _gebruikerRepository;

        public SessieController(IGebruikerRepository gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult Aanwezigheden(Lesgever lesgever)
        {
            IEnumerable<Lid> gebruikersLijst = _gebruikerRepository.GetAllLeden().AsEnumerable();
            //Sessie sessie = lesgever.startSessie(gebruikersLijst);
            return View(gebruikersLijst);
        }

        [HttpPost]
        public IActionResult RegistreerAanwezigheden(string aanwezigeLedenIds, string afwezigeLedenIds, Sessie sessie) {
            IEnumerable<string> aanwezigeLedenIdsArray = aanwezigeLedenIds.Split(",");
            IEnumerable<string> afwezigeLedenIdsArray = afwezigeLedenIds.Split(",");
            ICollection<Lid> aanwezigeLeden = new List<Lid>();
            ICollection<Lid> afwezigeLeden = new List<Lid>();
            foreach(string id in aanwezigeLedenIdsArray) {
                aanwezigeLeden.Add((Lid)_gebruikerRepository.GetByGebruikernaam(id));
            }
            foreach(string id in afwezigeLedenIdsArray) {
                afwezigeLeden.Add((Lid)_gebruikerRepository.GetByGebruikernaam(id));
            }
            sessie.RegistreerAanwezigheden(aanwezigeLeden.AsEnumerable(), afwezigeLeden.AsEnumerable());
            return View("Aanmelden", aanwezigeLeden);
        }

    }
}