using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReversiMvcApp.Models;
using ReversiRestApi.Data;
using System.Diagnostics;
using System.Security.Claims;

namespace ReversiMvcApp.Controllers
{
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


        // GET: SpellenControllers/Details/5
        public ActionResult Details(string id)
        {
            return View();
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


        // GET: SpellenControllers/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: SpellenControllers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
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
        public ActionResult Spel() {
            return View();
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
        return RedirectToAction(nameof(Spel));
        }
    }
}
