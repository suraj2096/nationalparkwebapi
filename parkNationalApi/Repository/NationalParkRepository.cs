using parkNationalApi.Data;
using parkNationalApi.Models;
using parkNationalApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parkNationalApi.Repository
{
    public class NationalParkRepository:INationalParkRepository
    {
        private readonly ApplicationDbContext _context;
        public NationalParkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _context.NationalPark.Add(nationalPark);
            return save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _context.Remove(nationalPark);
            return save();
        }

        public NationalPark getNationalPark(int NationalParkId)
        {
            return _context.NationalPark.Find(NationalParkId);
        }

        public ICollection<NationalPark> getNationalParks()
        {
            return _context.NationalPark.ToList();
        }

        public bool NationalParkExists(int NationalParkId)
        {
            return _context.NationalPark.Any<NationalPark>(np=> np.Id == NationalParkId);
        }

        public bool NationalParkExists(string NationalParkName)
        {
            return _context.NationalPark.Any<NationalPark>(np => np.Name == NationalParkName);
        }

        public bool save()
        {
            return (_context.SaveChanges() == 1) ? true : false;
        }

        public bool UpdateNationlaPark(NationalPark nationaPark)
        {
            _context.NationalPark.Update(nationaPark);
            return save();
        }
    }
}
