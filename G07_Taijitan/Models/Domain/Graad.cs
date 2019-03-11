using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class Graad {
        public enum graad
        {
            Kyu6 = 1,
            Kyu5 = 2,
            Kyu4 = 3,
            Kyu3 = 4,
            Kyu2 = 5,
            Kyu1 = 6,
            Dan1 = 7,
            Dan2 = 8,
            Dan3 = 9,
            Dan4 = 10,
            Dan5 = 11,
            Dan6 = 12,
            Dan7 = 13,
            Dan8 = 14
        };
        
        public IEnumerable<graad> GetAllowedGraden(int gebruikergraad)
        {
            List<graad> list = null;
            foreach(graad e in (graad[]) Enum.GetValues(typeof (graad)))
            {
                if((int)e <= gebruikergraad)
                {
                    list.Add(e);
                }

            }
            return list;
        }

    }
}