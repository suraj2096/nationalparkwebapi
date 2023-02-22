using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ParkWebApp.Models;
using ParkWebApp.Models.View_Model;
using ParkWebApp.Repository.irepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INationalParkRepository _nationalparkrepository;
        private readonly ITrailReposiory _trailrepository;



        public HomeController(ILogger<HomeController> logger,INationalParkRepository nationalparkrepository,ITrailReposiory trailrepository)
        {
            _nationalparkrepository = nationalparkrepository;
            _trailrepository = trailrepository;
        }

        public async Task<IActionResult> Index()
        {
            IndexVM indexvm = new IndexVM()
            {
                nationalParkList = await _nationalparkrepository.GetsAsync(SD.NatinalParkAPIPath),
                trailList = await _trailrepository.GetsAsync(SD.TrailAPIPath)
            };
            return View(indexvm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
