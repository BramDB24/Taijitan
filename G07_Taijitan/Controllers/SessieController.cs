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

namespace G07_Taijitan.Controllers
{
    public class SessieController : Controller
    {
        
        private IGebruikerRepository _gebruikerRepository;
        private ISessieRepository _sessieRepository;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public SessieController(IGebruikerRepository gebruikerRepository, ISessieRepository sessieRepository, 
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _gebruikerRepository = gebruikerRepository;
            _sessieRepository = sessieRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        
        public IActionResult Aanwezigheden()
        {
            IEnumerable<Lid> gebruikersLijst = _gebruikerRepository.GetAllLeden().AsEnumerable();
            return View(gebruikersLijst);
        }

        [HttpPost]
        [ServiceFilter(typeof(SessieFilter))]
        public IActionResult RegistreerAanwezigheden(string aanwezigeLedenIds, string afwezigeLedenIds, Sessie sessie) {
            IEnumerable<string> aanwezigeLedenIdsArray = aanwezigeLedenIds.Split(",");
            IEnumerable<string> afwezigeLedenIdsArray = afwezigeLedenIds.Split(",");
            IEnumerable<Lid> aanwezigeLeden = aanwezigeLedenIdsArray.Select(l => (Lid)_gebruikerRepository.GetByGebruikernaam(l));
            IEnumerable<Lid> afwezigeLeden = afwezigeLedenIdsArray.Select(l => (Lid)_gebruikerRepository.GetByGebruikernaam(l));
            sessie.RegistreerAanwezigheden(aanwezigeLeden.AsEnumerable(), afwezigeLeden.AsEnumerable());
            _sessieRepository.Add(sessie);
            _sessieRepository.SaveChanges();
            return RedirectToAction(nameof(AanwezigeLeden));
        }

        [ServiceFilter(typeof(SessieFilter))]
        public IActionResult AanwezigeLeden(Sessie sessie) {
            IEnumerable<Lid> aanwezigeLeden = sessie.Ledenlijst.Where(l => l.Aanwezigheid).Select(l => l.Lid).AsEnumerable();
            return View("Aanmelden", aanwezigeLeden);
        }

        [ServiceFilter(typeof(SessieFilter))]
        public async Task<IActionResult> Aanmelden(string id, Sessie sessie) { //id = gebruikersnaam
            Gebruiker lid = _gebruikerRepository.GetByGebruikernaam(id);
            if(lid == null)
                return NotFound();
            if(!sessie.Ledenlijst.Any(ls => ls.Lid == lid)) {
                //no permission page
            }
            var impersonatedUser = await _userManager.FindByNameAsync(id);
            await _signInManager.SignOutAsync(); //signout admin
            await _userManager.AddClaimAsync(impersonatedUser, new Claim(ClaimTypes.Role, "InSessie"));
            await _signInManager.SignInAsync(impersonatedUser, false); //Impersonate User
            return RedirectToAction("Index", "Graad");
        }

        [ServiceFilter(typeof(SessieFilter))]
        public async Task<IActionResult> EindeSessie(Sessie sessie) {
            foreach(var lid in sessie.getAanwezigeLeden()) {
                var user = await _userManager.FindByNameAsync(lid.Gebruikersnaam);
                await _userManager.RemoveClaimAsync(user, User.Claims.First(c=>c.Value=="InSessie"));
            }
            await _signInManager.SignOutAsync();
            return RedirectToAction("KeuzeScherm", "Home");
        }

    }
}