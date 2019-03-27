using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using G07_Taijitan.Filters;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.RepoInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace G07_Taijitan.Controllers {
    public class SessieController : Controller {

        private IGebruikerRepository _gebruikerRepository;
        private ISessieRepository _sessieRepository;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public SessieController(IGebruikerRepository gebruikerRepository, ISessieRepository sessieRepository,
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            _gebruikerRepository = gebruikerRepository;
            _sessieRepository = sessieRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [ServiceFilter(typeof(SessieFilter))]
        [Authorize(Policy = "Lesgever")]
        public IActionResult Aanwezigheden(Sessie sessie) {
            if(sessie.Ledenlijst.Any()) { //indien er nog geen leden geregistreerd zijn voor de huidige dag, mag er geregistreerd worden
                return RedirectToAction(nameof(AanwezigeLeden));
            }
            sessie = new Sessie();
            IEnumerable<Lid> gebruikersLijst = _gebruikerRepository.GetLedenVoorSessieOp(sessie.Dag).AsEnumerable();
            return View(gebruikersLijst);
        }

        [HttpPost]
        [ServiceFilter(typeof(SessieFilter))]
        public IActionResult RegistreerAanwezigheden(string aanwezigeLedenIds, string afwezigeLedenIds, Sessie sessie) {
            IEnumerable<Lid> aanwezigeLeden = new List<Lid>();
            IEnumerable<Lid> afwezigeLeden = new List<Lid>();
            if(aanwezigeLedenIds != null)
                aanwezigeLeden = aanwezigeLedenIds.Split(",").Select(l => _gebruikerRepository.GetLidByGebruikersnaam(l));
            if(afwezigeLedenIds != null)
                afwezigeLeden = afwezigeLedenIds.Split(",").Select(l => _gebruikerRepository.GetLidByGebruikersnaam(l));
            sessie.RegistreerAanwezigheden(aanwezigeLeden.AsEnumerable(), afwezigeLeden.AsEnumerable());
            _sessieRepository.Add(sessie);
            _sessieRepository.SaveChanges(); //sessie toegevoegd
            _gebruikerRepository.SaveChanges(); //punten leden toegevoegd
            return RedirectToAction(nameof(AanwezigeLeden));
        }

        [ServiceFilter(typeof(SessieFilter))]
        public IActionResult AanwezigeLeden(Sessie sessie) {
            IEnumerable<Lid> aanwezigeLeden = sessie.getAanwezigeLeden();
            return View("Aanmelden", aanwezigeLeden);
        }

        [ServiceFilter(typeof(SessieFilter))]
        public async Task<IActionResult> Aanmelden(string id, Sessie sessie) { //id = gebruikersnaam
            Gebruiker lid = _gebruikerRepository.GetByGebruikernaam(id);
            if(lid == null)
                return NotFound();
            if(!sessie.Ledenlijst.Any(ls => ls.Lid == lid)) {
                return Forbid();
            }
            var user = await _userManager.FindByNameAsync(id);
            await _signInManager.SignOutAsync(); //sign out last person
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "InSessie"));
            await _signInManager.SignInAsync(user, false); //Impersonate User
            return RedirectToAction("Index", "Graad");
        }


        [ServiceFilter(typeof(GebruikerFilter))]
        [ServiceFilter(typeof(SessieFilter))]
        public async Task<IActionResult> EindeSessie(Sessie sessie, Gebruiker gebruiker) {
            if(sessie == null) {
                return NotFound();
            }
            if(!(gebruiker is Lesgever)) {
                var user = await _userManager.FindByNameAsync(gebruiker.Gebruikersnaam);
                await _userManager.RemoveClaimAsync(user, User.Claims.First(c => c.Value == "InSessie"));
            }
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Graad");
        }

    }
}