﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Models.GebruikersViewModel;
using Microsoft.AspNetCore.Mvc;

namespace G07_Taijitan.Controllers {
    public class GebruikerController : Controller {
        private readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerController(IGebruikerRepository gebruikerRepository) {
            _gebruikerRepository = gebruikerRepository;
        }
        public IActionResult Index() {
            IEnumerable<Gebruiker> gebruikers = _gebruikerRepository.GetAllGebruikers();
            return View(gebruikers.OrderBy(v => v.Gebruikersnaam));
        }

        public IActionResult Edit(string id) { //id = gebruikersnaam    //! eig nog naam, moet nog aangepast worden (duplicates), zie repo
            Gebruiker user = _gebruikerRepository.GetByGebruikersnaam(id);
            return View(new GebruikersViewModel(user));
        }

        [HttpPost]
        public IActionResult Edit(string id, GebruikersViewModel gvm) { //id = gebruikersnaam
            Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaam(id);
            if(gebruiker == null)
                return NotFound();
            if(ModelState.IsValid) {
                try {
                    gebruiker.EditGebruiker(gvm.Naam, gvm.Voornaam, gvm.Telefoonnummer, gvm.GeboorteDatum); //email staat ni in gebruiker?
                    _gebruikerRepository.SaveChanges();
                } catch {
                    TempData["error"] = "Sorry, something went wrong, user not updated";
                }
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(gvm);
        }
    }
}
