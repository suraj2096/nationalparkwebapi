using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWebApp.Models.View_Model
{
    public class TrailVM
    {
        public Trail trail { get; set; }
        public IEnumerable<SelectListItem> NationalParkList { get; set; }
    }
}
