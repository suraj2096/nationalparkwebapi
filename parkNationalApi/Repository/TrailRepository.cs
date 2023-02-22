using Microsoft.EntityFrameworkCore;
using parkNationalApi.Data;
using parkNationalApi.Models;
using parkNationalApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parkNationalApi.Repository
{
    public class TrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext _context;
        public TrailRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateTrails(Trails trail)
        {
            _context.Trails.Add(trail);
            return Save();
        }

        public bool DeletleTrails(Trails trails)
        {
            _context.Trails.Remove(trails);
            return Save();
        }

        public Trails getTrail(int id)
        {
           return _context.Trails.Find(id);
        }

        public ICollection<Trails> getTrails()
        {
            return _context.Trails.Include(m => m.nationalPark).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool TrialExists(int id)
        {
            return _context.Trails.Any(u => u.Id == id);
        }

        public bool TrialExists(string name)
        {
            return _context.Trails.Any(u => u.Name == name);
        }

        public bool UpdateTrails(Trails trails)
        {
            _context.Trails.Update(trails);
            return Save();
        }
    }
}
