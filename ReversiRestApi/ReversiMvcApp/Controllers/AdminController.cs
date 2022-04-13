using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReversiMvcApp.Data;
using ReversiMvcApp.Helper;
using System.Security.Claims;

namespace ReversiMvcApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private reversiDbContext _context;
        private ClaimHelper _claimHelper;
        public AdminController(UserManager<IdentityUser> userManager, reversiDbContext context) { 
            _userManager = userManager;
            _context = context;
            _claimHelper = new ClaimHelper(userManager);
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Spelers.ToListAsync());
        }

        public async Task<IActionResult> DisplayModerators() {
            return View("index",await _claimHelper.ReturnSpelersWithRole(_context.Spelers.ToList(), ClaimHelper.Admin));
        }

        public async Task<IActionResult> DisplayAdmin() {

            return View("index",await _claimHelper.ReturnSpelersWithRole(_context.Spelers.ToList(),ClaimHelper.Admin));
        }


        public async Task<IActionResult> AddUserToModerator(string id) {


            await _claimHelper.AddUserToClaimRole(id,ClaimHelper.Moderator);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> AddUserToAdmin(string id) {

            await _claimHelper.AddUserToClaimRole(id, ClaimHelper.Admin);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveUserFromAdmin(string id)
        {

            await _claimHelper.RemoveUserFromClaim(id, ClaimHelper.Admin);

            return RedirectToAction("DisplayAdmin");
        }

        public async Task<IActionResult> RemoveUserFromModerator(string id)
        {

            await _claimHelper.RemoveUserFromClaim(id, ClaimHelper.Admin);

            return RedirectToAction("DisplayModerators");
        }
    }
}
