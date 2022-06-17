#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReversiMvcApp.Data;
using ReversiMvcApp.Models;

namespace ReversiMvcApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SpelersController : Controller
    {
        private readonly reversiDbContext _context;

        public SpelersController(reversiDbContext context)
        {
            _context = context;
        }

        // GET: Spelers  
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spelers.ToListAsync());
        }

        // GET: Spelers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spelers = await _context.Spelers
                .FirstOrDefaultAsync(m => m.Guid == id);
            if (spelers == null)
            {
                return NotFound();
            }

            return View(spelers);
        }

        // GET: Spelers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spelers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Guid,Name,AantalGewonnen,AantalVerloren,AantalGelijk")] Spelers spelers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spelers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spelers);
        }

        // GET: Spelers/Edit/5 
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spelers = await _context.Spelers.FindAsync(id);
            if (spelers == null)
            {
                return NotFound();
            }
            return View(spelers);
        }

        // POST: Spelers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Guid,Name,AantalGewonnen,AantalVerloren,AantalGelijk")] Spelers spelers)
        {
            if (id != spelers.Guid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spelers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpelersExists(spelers.Guid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(spelers);
        }

        // GET: Spelers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spelers = await _context.Spelers
                .FirstOrDefaultAsync(m => m.Guid == id);
            if (spelers == null)
            {
                return NotFound();
            }

            return View(spelers);
        }

        // POST: Spelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var spelers = await _context.Spelers.FindAsync(id);
            _context.Spelers.Remove(spelers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpelersExists(string id)
        {
            return _context.Spelers.Any(e => e.Guid == id);
        }
    }
}
