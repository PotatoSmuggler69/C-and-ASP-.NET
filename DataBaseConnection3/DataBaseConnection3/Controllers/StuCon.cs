using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataBaseConnection3.Models;

namespace DataBaseConnection3.Controllers
{
    public class StuCon : Controller
    {
        private readonly StudentDbContext _context;

        public StuCon(StudentDbContext context)
        {
            _context = context;
        }

        // GET: StuCon
        public async Task<IActionResult> Index()
        {
              return View(await _context.StudentTbs.ToListAsync());
        }

        // GET: StuCon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentTbs == null)
            {
                return NotFound();
            }

            var studentTb = await _context.StudentTbs
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentTb == null)
            {
                return NotFound();
            }

            return View(studentTb);
        }

        // GET: StuCon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StuCon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,Department,Course")] StudentTb studentTb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentTb);
        }

        // GET: StuCon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentTbs == null)
            {
                return NotFound();
            }

            var studentTb = await _context.StudentTbs.FindAsync(id);
            if (studentTb == null)
            {
                return NotFound();
            }
            return View(studentTb);
        }

        // POST: StuCon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,Department,Course")] StudentTb studentTb)
        {
            if (id != studentTb.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTbExists(studentTb.StudentId))
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
            return View(studentTb);
        }

        // GET: StuCon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentTbs == null)
            {
                return NotFound();
            }

            var studentTb = await _context.StudentTbs
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentTb == null)
            {
                return NotFound();
            }

            return View(studentTb);
        }

        // POST: StuCon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentTbs == null)
            {
                return Problem("Entity set 'StudentDbContext.StudentTbs'  is null.");
            }
            var studentTb = await _context.StudentTbs.FindAsync(id);
            if (studentTb != null)
            {
                _context.StudentTbs.Remove(studentTb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTbExists(int id)
        {
          return _context.StudentTbs.Any(e => e.StudentId == id);
        }
    }
}
