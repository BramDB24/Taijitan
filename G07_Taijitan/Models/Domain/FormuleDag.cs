using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class FormuleDag {
        public Dag Dag { get; set; }
        public DagEnum DagNaam { get; set; }
        public Formule Formule { get; set; }
        public string FormuleNaam { get; set; }

        public FormuleDag() {

        }

        public FormuleDag(Dag dag, Formule formule) {
            Dag = dag;
            DagNaam = dag.Naam;
            Formule = formule;
            FormuleNaam = formule.FormuleNaam;
        }
        
    }
}
