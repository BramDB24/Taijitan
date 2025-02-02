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
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Oefening> _oefeningen;
        public OefeningRepository(ApplicationDbContext context)
        {
            _context = context;
            _oefeningen = context.Oefeningen;
        }

        public IEnumerable<Oefening> GetByGraadAndType(int graad, int type)
        {
            return _oefeningen.Where(o => (int)o.Graad == graad && (int)o.OefeningType == type).ToList();
            
        }
        
        public Oefening GetBy(int id) {
            return _oefeningen.Include(o=>o.Lesmateriaal).FirstOrDefault(o => o.OefeningId == id);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}