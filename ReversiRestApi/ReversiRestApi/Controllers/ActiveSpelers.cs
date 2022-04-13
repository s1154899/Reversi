using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReversiRestApi.Controllers
{
    public class ActiveSpelers : Controller
    {
        // GET: ActiveSpelers
        public ActionResult Index()
        {
            return View();
        }

        // GET: ActiveSpelers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActiveSpelers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActiveSpelers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ActiveSpelers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ActiveSpelers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ActiveSpelers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActiveSpelers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
