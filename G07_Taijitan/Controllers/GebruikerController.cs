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

        [Authorize(Policy = "Lid")]
        public IActionResult Edit(string id) {
            if(User.Identity.Name == null || id != User.Identity.Name)
                return NotFound();

            Gebruiker user = _gebruikerRepository.GetByGebruikernaam(id);
            if(user == null) {
                return NotFound();
            }
            return View(new GebruikersViewModel(user));
        }

        [HttpPost]
        [Authorize(Policy = "Lid")]
        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult Edit(string id, GebruikersViewModel gvm) {
            //id = gebruikersnaam
            if(ModelState.IsValid) {
                //if (gebruiker == null)
                //    return NotFound();
                Gebruiker gebruiker = null;
                try {
                    gebruiker = _gebruikerRepository.GetByGebruikernaam(id);

                    gebruiker.EditGebruiker(gvm.Email, gvm.Naam, gvm.Voornaam, gvm.Telefoonnummer, gvm.GeboorteDatum, gvm.Adres); //email staat ni in gebruiker?                    
                    _gebruikerRepository.SaveChanges();
                    TempData["message"] = $"Gebruiker {gebruiker.Voornaam} is succesvol aangepast";
                } catch(Exception e) {
                    ModelState.AddModelError("", e.Message);
                }

                return RedirectToAction(nameof(Index), "Home");

            }
            return View(nameof(Edit), gvm);
        }
    }
}