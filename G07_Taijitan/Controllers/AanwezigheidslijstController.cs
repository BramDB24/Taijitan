using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.AanwezigheidslijstViewModel;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Models.Domain.RepoInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace G07_Taijitan.Controllers
{
    public class AanwezigheidslijstController : Controller
    {
        private ISessieRepository _sessieRepository;
        public AanwezigheidslijstController(ISessieRepository sessieRepository) {
            _sessieRepository = sessieRepository;
        }

        [Authorize(Policy = "Lesgever")]
        public IActionResult Index(DateTime? sessieDatum = null)
        {
            DateTime date = sessieDatum.HasValue ? sessieDatum.Value.Date : DateTime.Now.Date;
            return View(new SessieViewModel(_sessieRepository.getByDay(date), date));
        }
    }
}