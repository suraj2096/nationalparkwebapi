using Microsoft.AspNetCore.Mvc;
using ParkWebApp.Models;
using ParkWebApp.Repository.irepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWebApp.Controllers
{
    public class NationalParkController : Controller
    {
        private readonly INationalParkRepository _nationalParkRepository;
        public NationalParkController(INationalParkRepository nationaParkRepository)
        {
            _nationalParkRepository = nationaParkRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            NationalPark nationalPark = new NationalPark();
            
            if(id == null)
            {
                return View(nationalPark); // create code
            }
            nationalPark = await _nationalParkRepository.GetAsync(SD.NatinalParkAPIPath, id.GetValueOrDefault());
            return View(nationalPark);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Upsert(NationalPark nationaparks)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;// here we get the files from form that user send
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using(var fs1 = files[0].OpenReadStream())
                    {
                        using(var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    nationaparks.Picture = p1;
                }
                    // update code
                    var nationlaparkindb = await _nationalParkRepository.GetAsync(SD.NatinalParkAPIPath, nationaparks.Id);
                    if(nationlaparkindb != null)
                {
                nationaparks.Picture = nationlaparkindb.Picture;
                }   
                    if (nationaparks.Id == 0)
                    {
                        await _nationalParkRepository.CreateAsync(SD.NatinalParkAPIPath, nationaparks);
                    }
                    else
                        await _nationalParkRepository.UpdateAsync(SD.NatinalParkAPIPath, nationaparks);
                
                    return RedirectToAction(nameof(Index));
            }
              return View(nationaparks);
            
        }
        #region Apis
        public async Task<IActionResult> getAll()
        {
            var nationalparkdata = await _nationalParkRepository.GetsAsync(SD.NatinalParkAPIPath);
            return Json(new { data = nationalparkdata });

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _nationalParkRepository.DeleteAsync(SD.NatinalParkAPIPath, id);
            if (status)
            {
                return Json(new { success = true, message = "Deleted successfully the national park" });
            }
            else
            {
                return Json(new { success = false, message = "Something went wrong !!!!!" });
            }
        }
        #endregion
    }
}
