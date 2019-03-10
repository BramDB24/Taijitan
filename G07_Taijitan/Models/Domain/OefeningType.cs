﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain
{
    public class OefeningType
    {
        public int TypeId { get; set; }
        public string TypeNaam { get; set; }

        //Temporary, moet IEnumerable worden, just for datainitializer purposes atm
        public IList<Oefening> OefeningenReeks { get; set; }
        public OefeningType()
        {
                
        }
    }
}
