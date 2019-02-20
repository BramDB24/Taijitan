using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace G07_Taijitan.Controllers
{
    public class GebruikerController : Controller
    {
        private readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerController(IGebruikerRepository gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Gebruiker> gebruikers = _gebruikerRepository.GetGetAllGebruikers();
            return View(gebruikers.OrderBy(v => v.Gebruikersnaam));
        }
    }
}