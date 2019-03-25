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
        private ISessieRepository _sessieRepository;

        public SessieController(IGebruikerRepository gebruikerRepository, ISessieRepository sessieRepository)
        {
            _gebruikerRepository = gebruikerRepository;
            _sessieRepository = sessieRepository;
        }

        
        public IActionResult Aanwezigheden()
        {
            IEnumerable<Lid> gebruikersLijst = _gebruikerRepository.GetAllLeden().AsEnumerable();
            return View(gebruikersLijst);
        }

        [HttpPost]
        [ServiceFilter(typeof(SessieFilter))]
        public IActionResult RegistreerAanwezigheden(string aanwezigeLedenIds, string afwezigeLedenIds, Sessie sessie) {
            IEnumerable<string> aanwezigeLedenIdsArray = aanwezigeLedenIds.Split(",");
            IEnumerable<string> afwezigeLedenIdsArray = afwezigeLedenIds.Split(",");
            IEnumerable<Lid> aanwezigeLeden = aanwezigeLedenIdsArray.Select(l => (Lid)_gebruikerRepository.GetByGebruikernaam(l));
            IEnumerable<Lid> afwezigeLeden = afwezigeLedenIdsArray.Select(l => (Lid)_gebruikerRepository.GetByGebruikernaam(l));
            sessie.RegistreerAanwezigheden(aanwezigeLeden.AsEnumerable(), afwezigeLeden.AsEnumerable());
            _sessieRepository.Add(sessie);
            _sessieRepository.SaveChanges();
            return View("Aanmelden", aanwezigeLeden);
        }

        [ServiceFilter(typeof(SessieFilter))]
        public IActionResult Aanmelden(Sessie sessie, string id) { //id = gebruikersnaam
            Gebruiker lid = _gebruikerRepository.GetByGebruikernaam(id);
            if(lid == null)
                return NotFound();
            if(!sessie.Ledenlijst.Any(ls => ls.Lid == lid)) {
                //no permission page
            }
            return RedirectToAction("Index", "Graad");
        }

    }
}