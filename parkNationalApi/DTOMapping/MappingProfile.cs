using AutoMapper;
using parkNationalApi.Models;
using parkNationalApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parkNationalApi.DTOMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<NationalParkDto, NationalPark>().ReverseMap();// use this method when destination and source are known at compile time
            CreateMap<TrailDto, Trails>().ReverseMap(); // reveserMap() allow two way mapping
        }
    }
}
