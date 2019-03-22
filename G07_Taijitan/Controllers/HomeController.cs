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

namespace G07_Taijitan.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        [Authorize(Policy = "Lid")]
        public IActionResult KeuzeScherm(Gebruiker gebruiker)
        {
            if (!(gebruiker is Lesgever))
            {
                return RedirectToAction("Index", "Graad");
            }
            return View();

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
