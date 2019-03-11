using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using G07_Taijitan.Models;
using G07_Taijitan.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using G07_Taijitan.Filters;
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.RepoInterface;

namespace G07_Taijitan.Controllers {
    public class HomeController : Controller {
        IGebruikerRepository _gebruikerRepository;
        IOefeningRepository _oefeningRepository;

        public HomeController(IGebruikerRepository gebruikerRepository, IOefeningRepository oefeningRepository) {
            _gebruikerRepository = gebruikerRepository;
            _oefeningRepository = oefeningRepository;
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        [Authorize(Policy = "Lid")]
        public IActionResult Index(Gebruiker gebruiker) {
            Graad graad = gebruiker.Graad;
            //ICollection<Graad> graden = new List<Graad>();
            //for(int i = 0; i<=(int)graad; i++) {
            //    graden.Add((Graad)i);                   
            //}
            ViewData["Graad"] = gebruiker.Graad;
            return View();
        }

        [Authorize(Policy = "Lid")]
        public IActionResult Oefeningen(int id) { //id = graad
            return View(_oefeningRepository.GetByGraad(id));
        }

        public IActionResult OefeningTypes()
        {
            return View();
        }

        public IActionResult Lesmateriaal(int id) { //id = OefeningId
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
