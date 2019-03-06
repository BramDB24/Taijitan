using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using G07_Taijitan.Models;
using G07_Taijitan.Models.Domain;

namespace G07_Taijitan.Controllers {
    public class HomeController : Controller {
        IGebruikerRepository _gebruikerRepository;
        public HomeController(IGebruikerRepository gebruikerRepository) {
            _gebruikerRepository = gebruikerRepository;
        }

        public IActionResult Index() {
            ViewData["Graad"] = HttpContext.User.Identity.IsAuthenticated? _gebruikerRepository.GetByGebruikernaam(HttpContext.User.Identity.Name).Graad : 1;
            return View();
        }

        public IActionResult Oefeningen(int id) {
            Gebruiker user = HttpContext.User.Identity.IsAuthenticated ? _gebruikerRepository.GetByGebruikernaam(HttpContext.User.Identity.Name) : null;
            return View(user.Oefeningen);
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
