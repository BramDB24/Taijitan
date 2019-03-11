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
        private readonly IOefeningRepository _oefeningRepository;
        private int graadid;
        public GraadController(IOefeningTypeRepository oefeningTypeRepository, IOefeningRepository oefeningRepository)
        {
            _oefeningTypeRepository = oefeningTypeRepository;
            _oefeningRepository = oefeningRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult OefeningType(int graadid)
        {
            this.graadid = graadid;
            IEnumerable<OefeningType> oefeningTypes = _oefeningTypeRepository.GetAll();
            if (oefeningTypes == null)
                return NotFound();

            return View(oefeningTypes);
        }

        
        public IActionResult Oefening(int id)
        {
            IEnumerable<Oefening> oefeningen = _oefeningRepository.GetByGraadAndType(graadid,id);
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