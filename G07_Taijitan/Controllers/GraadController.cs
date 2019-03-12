using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Filters;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.LesMateriaal;
using G07_Taijitan.Models.Domain.RepoInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace G07_Taijitan.Controllers {
    public class GraadController : Controller {        
        private readonly IOefeningRepository _oefeningRepository;
        public GraadController(IOefeningRepository oefeningRepository) {            
            _oefeningRepository = oefeningRepository;
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        [Authorize(Policy = "Lid")]
        public IActionResult Index(Gebruiker gebruiker) {
            IEnumerable<Graad> graden = Enum.GetValues(typeof(Graad)).Cast<Graad>().Where(x => x < gebruiker.Graad).ToList();
            ViewData["HuidigeGraad"] = gebruiker.Graad;
            return View(graden);
        }

        
        public IActionResult OefeningType(int graadid) {            
            IEnumerable<OefeningType> oefeningTypes = Enum.GetValues(typeof(OefeningType)).Cast<OefeningType>();
            ViewData["Graad"] = graadid;
            return View(oefeningTypes);
        }

        
        public IActionResult Oefening(int graadid, int typeid) {
            IEnumerable<Oefening> oefeningen = _oefeningRepository.GetByGraadAndType(graadid, typeid);
            if(oefeningen == null)
                return NotFound();
            return View(oefeningen);
        }

        public IActionResult Videomateriaal(int oefeningid) {
            Oefening oefening = _oefeningRepository.GetBy(oefeningid);
            if(oefening == null) {
                return NotFound();
            }
            IEnumerable<Lesmateriaal> materiaal = oefening.Lesmateriaal.ToList();
            IList<Video> lijst = new List<Video>();
            foreach(var x in materiaal) {
                if(x is Video)
                    lijst.Add((Video)x);
            }

            //if(materiaal == null)
            //    return NotFound();
            return View(lijst);
        }

        public IActionResult Afbeeldingen(int oefeningid) {
            Oefening oefening = _oefeningRepository.GetBy(oefeningid);
            if(oefening == null) {
                return NotFound();
            }
            IEnumerable<Lesmateriaal> materiaal = oefening.Lesmateriaal.ToList();
            IList<Foto> lijst = new List<Foto>();
            foreach(var x in materiaal) {
                if(x is Foto)
                    lijst.Add((Foto)x);
            }
            return View(lijst);
        }

        public IActionResult Tekstbestanden(int oefeningid) {
            Oefening oefening = _oefeningRepository.GetBy(oefeningid);
            if(oefening == null) {
                return NotFound();
            }
            IEnumerable<Lesmateriaal> materiaal = oefening.Lesmateriaal.ToList();
            IList<Tekst> lijst = new List<Tekst>();
            foreach(var x in materiaal) {
                if(x is Tekst)
                    lijst.Add((Tekst)x);
            }
            return View(lijst);
        }
    }
}