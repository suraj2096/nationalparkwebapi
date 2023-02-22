using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWebApp.Models
{
    public class Trail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Distance { get; set; }
        public string Elevation { get; set; }
        public DateTime DateCreated { get; set; }
        public enum DifficultyType { Easy, Moderate, Difficult };
        public DifficultyType Difficulty { get; set; }
        public int NationalParkId { get; set; }
        public NationalPark nationalPark { get; set; }
    }
}
