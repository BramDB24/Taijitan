using System;
using System.Collections.Generic;
using System.Linq;
using G07_Taijitan.Filters;
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.RepoInterface;
using G07_Taijitan.Models.GebruikersViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace G07_Taijitan.Controllers
{
    /* change at 2402 authorize tagg en servicefilter tagg toegevoegd aan httppost*/

    [Authorize(Policy = "Lid")]
    [ServiceFilter(typeof(GebruikerFilter))]
    public class GebruikerController : Controller
    {
        private readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerController(IGebruikerRepository gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Gebruiker> gebruikers = _gebruikerRepository.GetAllGebruikers();
            return View(gebruikers.OrderBy(v => v.Gebruikersnaam));
        }

        public IActionResult Edit(Gebruiker gebruiker)
        {   
            if (gebruiker == null)
            {
                return NotFound();
            }

            return View(new GebruikersViewModel(gebruiker)); 
        }

        [HttpPost]        
        public IActionResult Edit(Gebruiker gebruiker, GebruikersViewModel gvm)
        {   
            if (ModelState.IsValid)
            {                
                try
                {
                    Gebruiker _gebruiker = gebruiker;
                    _gebruiker.EditGebruiker(gvm.Email, gvm.Naam, gvm.Voornaam, gvm.Telefoonnummer, gvm.GeboorteDatum/*, gvm.Adres*/);
                    _gebruikerRepository.SaveChanges();
                    TempData["message"] = $"Gebruiker {gebruiker.Voornaam} is succesvol aangepast";
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }

                return RedirectToAction(nameof(Index), "Graad");

            }
            return View(nameof(Edit), gvm);
        }
    }
}