using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkWebApp.Repository.irepository;
using ParkWebApp.Models;
using ParkWebApp.Models.View_Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ParkWebApp.Controllers
{
    public class TrailController : Controller
    {
        private readonly ITrailReposiory _trialRepository;
        private readonly INationalParkRepository _nationalParkRepository;
        TrailVM trailvm;
        public TrailController(ITrailReposiory trailrepository,INationalParkRepository nationlaParkRepository)
        {
             
            _trialRepository = trailrepository;
            _nationalParkRepository = nationlaParkRepository;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<NationalPark> nationalparklist = await _nationalParkRepository.GetsAsync(SD.NatinalParkAPIPath);
            trailvm = new TrailVM()
            {
                trail = new Trail(),
                NationalParkList = nationalparklist.Select(np => new SelectListItem()
                {
                    Text = np.Name,
                    Value = np.Id.ToString()
                })
            };
            if (id == null) return View(trailvm);
            trailvm.trail = await _trialRepository.GetAsync(SD.TrailAPIPath, id.GetValueOrDefault());
            if (trailvm.trail == null)
                return NotFound();
            return View(trailvm);  
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(TrailVM trailVM)
        {
            if (ModelState.IsValid)
            {
                if (trailVM.trail.Id == 0)
                    await _trialRepository.CreateAsync(SD.TrailAPIPath, trailVM.trail);
                else
                    await _trialRepository.UpdateAsync(SD.TrailAPIPath, trailVM.trail);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                IEnumerable<NationalPark> nationalparklist = await _nationalParkRepository.GetsAsync(SD.NatinalParkAPIPath);
                trailvm = new TrailVM()
                {
                    trail = trailVM.trail,
                    NationalParkList = nationalparklist.Select(m => new SelectListItem()
                    {
                        Text = m.Name,
                        Value = m.Id.ToString()
                    })
                };
                return View(trailvm);
            }
        }
        #region apis
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var data = await _trialRepository.GetsAsync(SD.TrailAPIPath);
            return Json(new { data = data });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            
            var status = await _trialRepository.DeleteAsync(SD.TrailAPIPath, id);
            if (status)
            {
            return Json(new { success = true, message = "Successfully deleted the record" });
            }
            else
            {
                return Json(new { success = false, message = "something went wrong to delete record" });
            }
        }
        #endregion
    }
}
