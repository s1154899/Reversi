using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReversiMvcApp.Data;
using ReversiMvcApp.Helper;
using ReversiMvcApp.Models;
using ReversiRestApi.Model;

namespace ReversiMvcApp.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class ModeratorController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private reversiDbContext _context;
        private ClaimHelper _claimHelper;
        public ModeratorController(UserManager<IdentityUser> userManager, reversiDbContext context) { 
        
        
            _userManager = userManager;
            _context = context;
            _claimHelper = new ClaimHelper(userManager);

        }
        public async Task<IActionResult> Index()
        {

            return View(await _context.Spelers.ToListAsync());

        }

        public async Task<IActionResult> Remove(string id) {

            _context.Spelers.Remove(_context.Spelers.First(s => s.Guid == id));
            _context.SaveChanges();            
            foreach (Spel s in APIReversi.GetSpellenSpeler(id).Result) {
                APIReversi.PostRemoveSPel(s.Token);
            }

            return RedirectToAction("Index");

        }
    }
}
