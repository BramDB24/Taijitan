using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class Graad {

        //public string Naam { get; set;}
        //public int GraadNiveau { get; set; }
        ////public string Image { get;}
        //public ICollection<Oefening> Oefeningen { get; set;}

        //public Graad() {
        //}

        //public Graad(string naam) {
        //    Naam = naam;
        //}

        public enum Graden 
        {
            kyu1 = 1,
            kyu2 = 2,
            kyu3 = 3,
            dan1 = 4,
            dan2 = 5,
            dan3 = 6
        };
    }
}
