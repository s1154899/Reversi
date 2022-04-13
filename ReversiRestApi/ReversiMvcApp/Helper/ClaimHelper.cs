using Microsoft.AspNetCore.Identity;
using ReversiMvcApp.Models;
using System.Security.Claims;

namespace ReversiMvcApp.Helper
{
    public class ClaimHelper
    {

        public static string Moderator = "Moderator";
        public static string Admin = "Admin";
        private UserManager<IdentityUser> _userManager;
        public ClaimHelper(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            
        }

        public async Task<bool> AddUserToClaimRole(string id,string Role) {

            IdentityUser user = await _userManager.FindByIdAsync(id);

            if (user == null || !_userManager.GetClaimsAsync(user).Result.Any(s => s.Value == Role))
            {
                var claim = new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", Role );
                IdentityResult result = await _userManager.AddClaimAsync(user, claim);
                return result.Succeeded;
            }
            return false;

        }

        public async Task<bool> RemoveUserFromClaim(string id, string Role)
        {

            IdentityUser user = await _userManager.FindByIdAsync(id);

            
                var claim = new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", Role);
                IdentityResult result = await _userManager.RemoveClaimAsync(user, claim);
                return result.Succeeded;
            
            return false;

        }


        public async Task<IEnumerable<Spelers>> ReturnSpelersWithRole(List<Spelers> spelers,string Role) {


            return spelers.Where(s => _userManager.GetClaimsAsync( _userManager.FindByIdAsync(s.Guid).Result).Result.Any(s => s.Value == Role));
        }


    }
}
