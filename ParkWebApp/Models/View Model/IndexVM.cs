using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWebApp.Models.View_Model
{
    public class IndexVM
    {
        public IEnumerable<NationalPark> nationalParkList { get; set; }
        public IEnumerable<Trail> trailList { get; set; }

    }
}
