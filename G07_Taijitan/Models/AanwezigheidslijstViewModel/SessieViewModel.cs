using G07_Taijitan.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.AanwezigheidslijstViewModel {
    public class SessieViewModel {

        [Display(Name = "Filter op datum")]
        [DataType(DataType.Date)]
        public DateTime SessieDatum { get; set; }
        public IEnumerable<LidSessie> Leden { get; set; }

        public SessieViewModel(Sessie sessie, DateTime sessieDatum) {
            SessieDatum = sessieDatum;
            Leden = sessie?.Ledenlijst;
        }
    }
}
