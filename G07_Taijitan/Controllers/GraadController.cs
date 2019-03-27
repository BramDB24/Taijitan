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
    [Authorize(Policy = "Lid")]
    public class GraadController : Controller {
        private readonly IOefeningRepository _oefeningRepository;
        private readonly IGebruikerRepository _gebruikerRepository;
        public GraadController(IOefeningRepository oefeningRepository, IGebruikerRepository gebruikerRepository) {
            _oefeningRepository = oefeningRepository;
            _gebruikerRepository = gebruikerRepository;
        }

        [ServiceFilter(typeof(GebruikerFilter))]        
        public IActionResult Index(Gebruiker gebruiker) {
            IEnumerable<Graad> graden = Enum.GetValues(typeof(Graad)).Cast<Graad>().Where(x => x < gebruiker.Graad).ToList();
            ViewData["HuidigeGraad"] = gebruiker.Graad;
            return View(graden);
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult OefeningType(Gebruiker gebruiker, int graadid) {
            IEnumerable<OefeningType> oefeningTypes = Enum.GetValues(typeof(OefeningType)).Cast<OefeningType>();
            if((int)gebruiker.Graad < graadid) {
                return Forbid();
            }
            ViewData["Graad"] = graadid;
            return View(oefeningTypes);
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult Oefening(Gebruiker gebruiker, int graadid, int typeid) {
            IEnumerable<Oefening> oefeningen = _oefeningRepository.GetByGraadAndType(graadid, typeid);
            if(oefeningen == null || oefeningen.Count() == 0)
                return NotFound();
            if((int)gebruiker.Graad<graadid) {
                return Forbid();
            }
            return View(oefeningen);
        }
        

        public JsonResult OnGetMateriaal(int oefeningId)
        {
            ///geeft een lijst terug van al het oefening materiaal en return dit als jsonresult
            var result = _oefeningRepository.GetBy(oefeningId).Lesmateriaal.ToList();
            return new JsonResult(result);
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult OefeningMaterialView(int oefeningId)
        {
            ///methode voor het tonen van de view
            int id = oefeningId;
            ViewData["oefeningid"] = oefeningId;
            return View();
        }

        [HttpPost]
        [ServiceFilter(typeof(GebruikerFilter))]
        public void getcommentaar(Gebruiker gebruiker, string comment, int oefeningid)
        {
            Oefening oefening = _oefeningRepository.GetBy(oefeningid);
            if(oefening != null) {
                oefening.addCommentaar(gebruiker, comment);
                _oefeningRepository.SaveChanges();
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(GebruikerFilter))]
        public void getConsult(Gebruiker gebruiker, int oefeningid)
        {
            Gebruiker lid = _gebruikerRepository.GetByGebruikernaam(gebruiker.Gebruikersnaam);
            if(lid != null) {
                lid.AddGebruikerOefening(gebruiker, oefeningid);
                _gebruikerRepository.SaveChanges();
            }
        }
    }
}