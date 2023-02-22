using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWebApp.Models
{
    public class NationalPark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public byte[] Picture { get; set; }
        public DateTime Created { get; set; }
        [Display(Name="Created Date")]
        public DateTime Established { get; set; }
    }
}
