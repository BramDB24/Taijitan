﻿using System.Collections.Generic;

namespace G07_Taijitan.Models.Domain.RepoInterface
{
    public interface IOefeningRepository
    {
        Oefening GetBy(int id);
        IEnumerable<Oefening> GetAll();        
        IEnumerable<Oefening> GetByGraadAndType(int graad, int type);
        IEnumerable<Oefening> GetByGraad(int graad);
    }
}
