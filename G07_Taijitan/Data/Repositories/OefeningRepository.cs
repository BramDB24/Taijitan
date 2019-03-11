﻿using G07_Taijitan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain.RepoInterface;

namespace G07_Taijitan.Data.Repositories
{
    public class OefeningRepository : IOefeningRepository
    {
        private readonly DbSet<Oefening> _oefeningen;
        public OefeningRepository(ApplicationDbContext context)
        {
            _oefeningen = context.Oefeningen;
        }

        public IEnumerable<Oefening> GetAll()
        {
            return _oefeningen.ToList();
        }

        public IEnumerable<Oefening> GetByGraadAndType(int graad, int type)
        {
            return _oefeningen.Where(t => t.TypeId == type && (int)t.Graad == graad).ToList();
        }

        public IEnumerable<Oefening> GetByGraad(int graad)
        {
            return _oefeningen.Where(o => (int)o.Graad == graad).ToList();
        }
    }
}