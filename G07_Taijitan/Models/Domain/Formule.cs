﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class Formule {
        public string FormuleNaam { get; set; }
        public IEnumerable<FormuleDag> Dagen { get; set; }
        public Formule() {
        }
    }
}
