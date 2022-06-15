﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReversiMvcApp.Data;
using ReversiMvcApp.Models;
using System.Configuration;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace ReversiMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly reversiDbContext _context;

        public HomeController(ILogger<HomeController> logger, reversiDbContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            foreach (IdentityUser user in _userManager.Users) {
                Debug.WriteLine(user.Id);
                Debug.WriteLine(user.UserName);
                Debug.WriteLine(user.Email);
                Debug.WriteLine(user.EmailConfirmed);
                Debug.WriteLine(user.PasswordHash);
                Debug.WriteLine(user.TwoFactorEnabled);

            }

            if (User.Identity.IsAuthenticated)
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (!_context.Spelers.Any(speler => speler.Guid == currentUserID))
                {
                    _context.Add(new Spelers() { Guid = currentUserID, AantalGelijk = 0, AantalGewonnen = 0, AantalVerloren = 0, Name = this.User.Identity.Name });
                    _context.SaveChanges();
                    Debug.WriteLine("user has been created");
                }


            }

            return View();
        }

        public IActionResult Privacy()
        {

            Debug.WriteLine(APIReversi.GetWaitingSpel().Result);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}