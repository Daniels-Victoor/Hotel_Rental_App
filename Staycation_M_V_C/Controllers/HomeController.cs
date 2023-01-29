using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Staycation.Core.Interface;
using Staycation.Infrastructures.Interface;
using Staycation_M_V_C.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Staycation_M_V_C.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IHotelServices _hotelServices;

        public HomeController( IHotelServices hotelServices)
        {
            _hotelServices = hotelServices;

        
        }


        // GET: Students
        public async Task<IActionResult> Index()
        {
           
            ViewBag.message = HttpContext.Session.GetString("userId");
            ViewBag.userEmail = HttpContext.Session.GetString("userEmail");
            return View(await _hotelServices.GetAllHotelAsync());
        }


        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var hotel = await _hotelServices.GetHotelByIdAsync(id);
              
                if (HttpContext.Session.GetString("userId") != null)
                {
                    ViewBag.userEmail = HttpContext.Session.GetString("userEmail");
                    ViewBag.message = HttpContext.Session.GetString("userId");
                    return View(hotel);
                }
                return RedirectToAction("Login", "Authentication");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }

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
