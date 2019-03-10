using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Models.Domain.LesMateriaal;
using G07_Taijitan.Models.Domain.RepoInterface;
using Microsoft.AspNetCore.Mvc;

namespace G07_Taijitan.Controllers
{
    public class GraadController : Controller
    {
        private readonly IOefeningTypeRepository _oefeningTypeRepository;

        public GraadController(IOefeningTypeRepository oefeningTypeRepository)
        {
            _oefeningTypeRepository = oefeningTypeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OefeningTypes()
        {
            IEnumerable<OefeningType> oefeningTypes = _oefeningTypeRepository.GetAll();
            if (oefeningTypes == null)
                return NotFound();

            return View(oefeningTypes);
        }

        [HttpPost]
        public IActionResult Oefeningen(OefeningType type)
        {
            IEnumerable<Oefening> oefeningen = type.OefeningenReeks;
            if (oefeningen == null)
                return NotFound();
            return View(oefeningen);
        }

        public IActionResult Materiaal(Oefening oefening)
        {
            IEnumerable<Lesmateriaal> materiaal = oefening.Lesmateriaal;
            return View(materiaal);
        }
    }
}