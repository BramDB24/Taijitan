using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class Dag {
        public DagEnum Naam { get; set; }
        public IEnumerable<FormuleDag> Formules { get; set; } //!

        public Dag() {

        }
    }
}
