using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace parkNationalApi.Models
{
    public class Trails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Distance { get; set; }
        public string Elevation { get; set; }
        public DateTime DateCreated { get; set; }
        // here we will define the enumeration and then use the enumeration here
        public enum DifficultyType { Easy, Moderate, Difficult };
        public DifficultyType Difficulty { get; set; }
        public int NationalParkId { get; set; }
        [ForeignKey("NationalParkId")]
        public NationalPark nationalPark { get; set; }
    }
}
