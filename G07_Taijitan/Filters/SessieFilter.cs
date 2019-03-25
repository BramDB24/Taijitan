using G07_Taijitan.Models.Domain;
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
        private Sessie _sessie;

        public SessieFilter(IGebruikerRepository gebruikerRepository) {
            _gebruikerRepository = gebruikerRepository;
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
                new Sessie() : JsonConvert.DeserializeObject<Sessie>(context.Session.GetString("sessie"));
            Sessie sessie = new Sessie();
            foreach (var l in sessiemetids.Ledenlijst) {
                sessie.AddLid(l.Lid);
            }
            return sessie;
        }

        private void WriteSessieToSession(Sessie sessie, HttpContext context) {
            context.Session.SetString("cart", JsonConvert.SerializeObject(sessie));
        }
    }
}
