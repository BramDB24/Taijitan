﻿using G07_Taijitan.Models.Domain.Gebruiker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain.RepoInterface
{
    public interface ISessieRepository
    {
        IEnumerable<Lid> getAllLeden();
        void Add(Sessie sessie);
        IEnumerable<Sessie> getAll();
        Sessie getByDay(DateTime dag);
        void SaveChanges();
    }
}
