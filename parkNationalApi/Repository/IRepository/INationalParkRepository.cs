using parkNationalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parkNationalApi.Repository.IRepository
{
   public interface INationalParkRepository
    {
        ICollection<NationalPark> getNationalParks();
        NationalPark getNationalPark(int NationalParkId);
        bool NationalParkExists(int NationalParkId);
        bool NationalParkExists(string NationalParkName);
        bool CreateNationalPark(NationalPark nationalPark);
        bool UpdateNationlaPark(NationalPark nationaPark);
        bool DeleteNationalPark(NationalPark nationalPark);
        bool save();
    }
}
