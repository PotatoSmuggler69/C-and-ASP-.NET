using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirstApproach.Data;
using CodeFirstApproach.Models;

namespace CodeFirstApproach.Controllers
{
    public class wowowController : Controller
    {
        private readonly CodeFirstApproachContext _context;

        public wowowController(CodeFirstApproachContext context)
        {
            _context = context;
        }

        // GET: wowow
        public async Task<IActionResult> Index()
        {
              return View(await _context.Random.ToListAsync());
        }

        // GET: wowow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Random == null)
            {
                return NotFound();
            }

            var waraWow = await _context.Random
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waraWow == null)
            {
                return NotFound();
            }

            return View(waraWow);
        }

        // GET: wowow/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: wowow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Author,pages,Count")] WaraWow waraWow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waraWow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waraWow);
        }

        // GET: wowow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Random == null)
            {
                return NotFound();
            }

            var waraWow = await _context.Random.FindAsync(id);
            if (waraWow == null)
            {
                return NotFound();
            }
            return View(waraWow);
        }

        // POST: wowow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Author,pages,Count")] WaraWow waraWow)
        {
            if (id != waraWow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waraWow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaraWowExists(waraWow.Id))
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
            return View(waraWow);
        }

        // GET: wowow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Random == null)
            {
                return NotFound();
            }

            var waraWow = await _context.Random
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waraWow == null)
            {
                return NotFound();
            }

            return View(waraWow);
        }

        // POST: wowow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Random == null)
            {
                return Problem("Entity set 'CodeFirstApproachContext.Random'  is null.");
            }
            var waraWow = await _context.Random.FindAsync(id);
            if (waraWow != null)
            {
                _context.Random.Remove(waraWow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaraWowExists(int id)
        {
          return _context.Random.Any(e => e.Id == id);
        }
    }
}
