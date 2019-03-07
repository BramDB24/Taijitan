using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using G07_Taijitan.Models;
using G07_Taijitan.Models.Domain;
using Microsoft.AspNetCore.Authorization;

namespace G07_Taijitan.Controllers {
    public class HomeController : Controller {
        IGebruikerRepository _gebruikerRepository;
        IOefeningRepository _oefeningRepository;

        public HomeController(IGebruikerRepository gebruikerRepository, IOefeningRepository oefeningRepository) {
            _gebruikerRepository = gebruikerRepository;
            _oefeningRepository = oefeningRepository;
        }

        [Authorize(Policy = "Lid")]
        public IActionResult Index() {
            ViewData["Graad"] = HttpContext.User.Identity.IsAuthenticated? _gebruikerRepository.GetByGebruikernaam(HttpContext.User.Identity.Name).Graad : 0;
            return View();
        }

        [Authorize(Policy = "Lid")]
        public IActionResult Oefeningen(int id) { //id = graad
            return View(_oefeningRepository.GetByGraad(id));
        }

        public IActionResult Lesmateriaal(int id) { //id = OefeningId
            return View();
        }
        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
