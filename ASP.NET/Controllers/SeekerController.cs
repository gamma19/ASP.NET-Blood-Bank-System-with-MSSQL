using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final2.Data;
using Final2.Models;

namespace Final2.Controllers
{
    public class SeekerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeekerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seeker
        public async Task<IActionResult> Index()
        {
              return _context.Seeker != null ? 
                          View(await _context.Seeker.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Seeker'  is null.");
        }

        // GET: Seeker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Seeker == null)
            {
                return NotFound();
            }

            var seeker = await _context.Seeker
                .FirstOrDefaultAsync(m => m.sSsn == id);
            if (seeker == null)
            {
                return NotFound();
            }

            return View(seeker);
        }

        // GET: Seeker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seeker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sSsn,sGender,sName,sLastName")] Seeker seeker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seeker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seeker);
        }

        // GET: Seeker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Seeker == null)
            {
                return NotFound();
            }

            var seeker = await _context.Seeker.FindAsync(id);
            if (seeker == null)
            {
                return NotFound();
            }
            return View(seeker);
        }

        // POST: Seeker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("sSsn,sGender,sName,sLastName")] Seeker seeker)
        {
            if (id != seeker.sSsn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seeker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeekerExists(seeker.sSsn))
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
            return View(seeker);
        }

        // GET: Seeker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Seeker == null)
            {
                return NotFound();
            }

            var seeker = await _context.Seeker
                .FirstOrDefaultAsync(m => m.sSsn == id);
            if (seeker == null)
            {
                return NotFound();
            }

            return View(seeker);
        }

        // POST: Seeker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Seeker == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Seeker'  is null.");
            }
            var seeker = await _context.Seeker.FindAsync(id);
            if (seeker != null)
            {
                _context.Seeker.Remove(seeker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeekerExists(int id)
        {
          return (_context.Seeker?.Any(e => e.sSsn == id)).GetValueOrDefault();
        }
    }
}
