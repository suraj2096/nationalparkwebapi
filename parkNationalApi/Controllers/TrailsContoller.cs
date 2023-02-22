using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using parkNationalApi.Models;
using parkNationalApi.Models.DTOs;
using parkNationalApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parkNationalApi.Controllers
{
    [Route("api/trail")]
    [ApiController]
    [Authorize]
    public class TrailsContoller : ControllerBase
    {
        private readonly ITrailRepository _trialRepository;
        private readonly IMapper _mapper;
        public TrailsContoller(ITrailRepository trialRepository,IMapper mapper)
        {
            _trialRepository = trialRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult getTrails()
        {
            var traildtolist = _trialRepository.getTrails().Select(_mapper.Map<Trails,TrailDto>);
            return Ok(traildtolist);
        }
        [HttpGet("{trailId:int}",Name ="getTrails")]
        public IActionResult getTrail(int trailId)
        {
            var trail = _trialRepository.getTrail(trailId);
            if (trail == null) return NotFound();
            var traildto = _mapper.Map<TrailDto>(trail);
            return Ok(traildto);
        }
        [HttpPost]
        public IActionResult CreateTrials([FromBody]TrailDto traildto)
        {
            if (traildto == null) return BadRequest(ModelState);
            if (_trialRepository.TrialExists(traildto.Id))
            {
                ModelState.AddModelError("", $"This trial is alredy exists {traildto.Name}");
            }
            // now here we will change the traildto to trail model
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var trail = _mapper.Map<Trails>(traildto);
            if (!_trialRepository.CreateTrails(trail))
            {
                ModelState.AddModelError("", $"Something went wrong to this trial to add {trail.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return CreatedAtRoute("getTrails", new { trailId = trail.Id }, trail);
        }
        [HttpPut]
        public IActionResult UpdateTrails([FromBody] TrailDto traildto)
        {
            if (traildto == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var trail = _mapper.Map<Trails>(traildto);
            if (!_trialRepository.UpdateTrails(trail))
            {
                ModelState.AddModelError("", $"Something went wrong to update the {trail.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }
        [HttpDelete("{TrailId:int}")]
        public IActionResult DeleteTrails(int TrailId)
        {
            if (!_trialRepository.TrialExists(TrailId))
            {
                return BadRequest(ModelState);
            }
            var trailexist = _trialRepository.getTrail(TrailId);
            if (!_trialRepository.DeletleTrails(trailexist))
            {
                ModelState.AddModelError("", $"Something went wrong to update the {trailexist.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
    }
}
