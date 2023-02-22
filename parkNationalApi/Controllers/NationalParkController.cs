using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using parkNationalApi.Models;
using parkNationalApi.Models.DTOs;
using parkNationalApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace parkNationalApi.Controllers
{
    [Route("api/NationalPark")] // statically gave the value
    [ApiController]
    [Authorize]
    public class NationalParkController : ControllerBase
    {
        
        private readonly INationalParkRepository _nationalParkRepository;
        private readonly IMapper _mapper;
        public NationalParkController(INationalParkRepository nationalParkRepository,IMapper mapper)
        {
            _nationalParkRepository = nationalParkRepository;
            _mapper = mapper;
        }

        // now first we will get all the records
        [HttpGet]
        public IActionResult GetNationalPark()
        {
            
            var nationalParkDtolist = _nationalParkRepository.getNationalParks().Select(_mapper.Map<NationalPark, NationalParkDto>);
            return Ok(nationalParkDtolist);
        }
        [HttpGet("{nationalParkId:int}",Name ="GetNationalPark")]
        public IActionResult getNationalPark(int nationalParkId)
        {
            var nationalPark = _nationalParkRepository.getNationalPark(nationalParkId);
            if (nationalPark == null) return NotFound();
            // convert it to dto 
            var nationalParkDto = _mapper.Map<NationalParkDto>(nationalPark);
            return Ok(nationalParkDto);
        }
        [HttpPost]
        public IActionResult CreateNationalPark([FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null) return BadRequest(ModelState);
            // now check national park exists or not
            if (_nationalParkRepository.NationalParkExists(nationalParkDto.Name))
            {
                ModelState.AddModelError("", $"this national park alredy exists {nationalParkDto.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            // now check the model form
            if (!ModelState.IsValid) return BadRequest(ModelState);
            // first map natinalparkdto to national park model
            var nationalPark = _mapper.Map<NationalPark>(nationalParkDto);
            if (!_nationalParkRepository.CreateNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something went wrong!!! {nationalParkDto.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return CreatedAtRoute("GetNationalPark", new { nationalParkId = nationalPark.Id },nationalPark);
        }
        [HttpPut]
        public IActionResult UpdateNationalPark([FromBody]NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            // convert nationalParkDto to nationalpark
            var nationalPark = _mapper.Map<NationalPark>(nationalParkDto);
            if (!_nationalParkRepository.UpdateNationlaPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something went wrong to update the {nationalPark.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent(); // 204 status code
        }

        [HttpDelete("{nationalParkId:int}")]
        public IActionResult DeleteNationalPark(int nationalParkId)
        {
            if (!_nationalParkRepository.NationalParkExists(nationalParkId))
            {
                return NotFound(); // 404 status code
            }
            var nationalPark = _nationalParkRepository.getNationalPark(nationalParkId);
            if(nationalPark == null)
            {
                return NotFound();
            }
            if (!_nationalParkRepository.DeleteNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something went wrong to delete data {nationalPark.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }


    }
}
