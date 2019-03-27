using G07_Taijitan.Models.Domain;
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.RepoInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Filters {
    public class SessieFilter : ActionFilterAttribute {
        private readonly IGebruikerRepository _gebruikerRepository;
        private readonly ISessieRepository _sessieRepository;
        private Sessie _sessie;

        public SessieFilter(IGebruikerRepository gebruikerRepository, ISessieRepository sessieRepository) {
            _gebruikerRepository = gebruikerRepository;
            _sessieRepository = sessieRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            _sessie = ReadSessieFromSession(context.HttpContext);
            context.ActionArguments["sessie"] = _sessie;
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context) {
            WriteSessieToSession(_sessie, context.HttpContext);
            base.OnActionExecuted(context);
        }

        private Sessie ReadSessieFromSession(HttpContext context) {
            Sessie sessiemetids = context.Session.GetString("sessie") == null ?
                _sessieRepository.getByDay(DateTime.Today) : JsonConvert.DeserializeObject<Sessie>(context.Session.GetString("sessie"));
            if(sessiemetids == null)
                return new Sessie();
            Sessie sessie = new Sessie();
            ICollection<Lid> aanwezigen = new List<Lid>();
            ICollection<Lid> afwezigen = new List<Lid>();
            foreach (var l in sessiemetids.Ledenlijst) {
                if(l.Aanwezigheid)
                    aanwezigen.Add(_gebruikerRepository.GetLidByGebruikersnaam(l.Gebruikersnaam));
                else
                    afwezigen.Add(_gebruikerRepository.GetLidByGebruikersnaam(l.Gebruikersnaam));
            }
            sessie.RegistreerAanwezigheden(aanwezigen, afwezigen);
            return sessie;
        }

        private void WriteSessieToSession(Sessie sessie, HttpContext context) {
            context.Session.SetString("sessie", JsonConvert.SerializeObject(sessie));
        }
    }
}
