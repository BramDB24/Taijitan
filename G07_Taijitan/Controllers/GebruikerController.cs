using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Filters;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Models.GebruikersViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace G07_Taijitan.Controllers {
    /* change at 2402 authorize tagg en servicefilter tagg toegevoegd aan httppost*/
    public class GebruikerController : Controller {
        private readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerController(IGebruikerRepository gebruikerRepository) {
            _gebruikerRepository = gebruikerRepository;
        }
        public IActionResult Index() {
            IEnumerable<Gebruiker> gebruikers = _gebruikerRepository.GetAllGebruikers();
            return View(gebruikers.OrderBy(v => v.Gebruikersnaam));
        }

        [Authorize(Policy = "Gebruiker")]
        public IActionResult Edit(string id) { //id = gebruikersnaam    //! eig nog naam, moet nog aangepast worden (duplicates), zie repo
            Gebruiker user = _gebruikerRepository.GetByGebruikernaam(id);
            return View(new GebruikersViewModel(user));
        }
        
        [HttpPost]
        [Authorize(Policy = "Gebruiker")]
        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult Edit(string id, GebruikersViewModel gvm) { //id = gebruikersnaam
            Gebruiker gebruiker = _gebruikerRepository.GetByGebruikernaam(id);
            if(gebruiker == null)
                return NotFound();
            if(ModelState.IsValid) {                
                try {
                    gebruiker.EditGebruiker(gvm.Email,gvm.Naam, gvm.Voornaam, gvm.Telefoonnummer, gvm.GeboorteDatum); //email staat ni in gebruiker?                    
                    _gebruikerRepository.SaveChanges();
                    TempData["message"] = $"Gebruiker {gebruiker.Voornaam} is succesvol aangepast";
                    return RedirectToAction(nameof(Index), "Home");
                } catch(Exception e) {
                    ModelState.AddModelError("", e.Message);                    
                }
            }
            return View(gvm);
        }
        
    }
}
