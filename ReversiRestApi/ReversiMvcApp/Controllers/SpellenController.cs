using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReversiMvcApp.Models;
using ReversiRestApi.Data;
using System.Diagnostics;
using System.Security.Claims;

namespace ReversiMvcApp.Controllers
{
    [Authorize]
    public class SpellenController : Controller
    {

        
        // GET: SpellenControllers
        public ActionResult Index()
        {
            return View("index",APIReversi.GetWaitingSpel().Result);
        }

        public ActionResult SpellenSpeler()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            return View("spellenSpeler", APIReversi.GetSpellenSpeler(currentUserID).Result);

        }

        // GET: SpellenControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpellenControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            Debug.WriteLine(collection["Omschrijving"]);
            Debug.WriteLine(currentUserID);

            APIReversi.PostCreateSpel(currentUserID, collection["Omschrijving"]);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Spel(string id) {

            return View("spel", APIReversi.GetSpel(id).Result);
        }

        [HttpGet]
        public ActionResult eindscherm()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Join(string id) {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            APIReversi.PostJoin(id,currentUserID).Wait();
            

        return View("spel", APIReversi.GetSpel(id).Result); 
        }
    }
}
