using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Staycation.Core.Interface;
using Staycation.M_V_C.Models;
using System;
using System.Threading.Tasks;

namespace Staycation.M_V_C.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserServices _userServices;
        public AuthenticationController(ILogger<AuthenticationController> logger, IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }

        public IActionResult Login()
        {
            UserLoginDetails userDetails = new UserLoginDetails(HttpContext.Session.GetString("userEmail"), HttpContext.Session.GetString("userPass"));
            return View(userDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDetails user)
        {
            if (ModelState.IsValid)
            {   
                var users = await _userServices.Login(user.Email, user.Password);
                if (users != null)
                {
                    HttpContext.Session.SetString("userId", users.UserId);
                    HttpContext.Session.SetString("userEmail", users.FullName);
                    HttpContext.Session.SetString("userPass", users.Password);

                    return RedirectToAction("Index", "Home" );
                 }
            }

            ModelState.AddModelError("Email", "this record  doesnt exist in the data base");
            return View(user);
        }
        public IActionResult Logout()
        {
            
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegistration user)
        {
            if (user.RetypePassword != user.Password)
            {
                ModelState.AddModelError("RetypePassword", "the Password those not match");
            }
            if (ModelState.IsValid)
            {
                var userInfo = await _userServices.RegisterUser(user.Email, user.Password, user.FirstName, user.LastName);
                if (userInfo != null)
                {
                    HttpContext.Session.SetString("userId", userInfo.UserId);
                    HttpContext.Session.SetString("userEmail", userInfo.Email);
                    HttpContext.Session.SetString("userPass", user.Password);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Email", "this email already exist");
                    return View(user);
                }
            }
            return View(user);
        }

    }
}
