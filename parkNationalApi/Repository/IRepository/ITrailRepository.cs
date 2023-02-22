using parkNationalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parkNationalApi.Repository.IRepository
{
    public interface ITrailRepository
    {
        ICollection<Trails> getTrails();
        Trails getTrail(int id);
        bool TrialExists(int id);
        bool TrialExists(string name);
        bool CreateTrails(Trails trail);
        bool UpdateTrails(Trails trails);
        bool DeletleTrails(Trails trails);
        bool Save();

    }
}
