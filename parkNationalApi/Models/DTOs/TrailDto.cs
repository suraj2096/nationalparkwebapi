using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static parkNationalApi.Models.Trails;

namespace parkNationalApi.Models.DTOs
{
    public class TrailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Distance { get; set; }
        public string Elevation { get; set; }
        public DateTime DateCreated { get; set; }
        public DifficultyType Difficulty { get; set; }
        public int NationalParkId { get; set; }
        public NationalPark nationalPark { get; set; }
    }
}
