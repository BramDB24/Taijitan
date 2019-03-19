using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Models.Domain.RepoInterface;
using Microsoft.AspNetCore.Mvc;

namespace G07_Taijitan.Controllers
{
    public class SessieController : Controller
    {
        private readonly Sessie _sessie;

        public SessieController(Sessie sessie)
        {
            _sessie = sessie;
        }
        public IActionResult Index()
        {
            return View(_sessie.Aanwezigheden);
        }
    }
}