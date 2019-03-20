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
            Sessie sessie = lesgever.startSessie(gebruikersLijst);
            return View(sessie);
        }
    }
}