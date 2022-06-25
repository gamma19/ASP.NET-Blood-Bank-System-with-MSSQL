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
    public class BloodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloodController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Blood
        public async Task<IActionResult> Index()
        {
              return _context.Blood != null ? 
                          View(await _context.Blood.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Blood'  is null.");
        }

        // GET: Blood/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Blood == null)
            {
                return NotFound();
            }

            var blood = await _context.Blood
                .FirstOrDefaultAsync(m => m.bTubeid == id);
            if (blood == null)
            {
                return NotFound();
            }

            return View(blood);
        }

        // GET: Blood/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blood/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("dSsn,hId,bbId,sSsn,bType,rhType,bTubeid,bAmount")] Blood blood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blood);
        }

        // GET: Blood/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Blood == null)
            {
                return NotFound();
            }

            var blood = await _context.Blood.FindAsync(id);
            if (blood == null)
            {
                return NotFound();
            }
            return View(blood);
        }

        // POST: Blood/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("dSsn,hId,bbId,sSsn,bType,rhType,bTubeid,bAmount")] Blood blood)
        {
            if (id != blood.bTubeid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodExists(blood.bTubeid))
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
            return View(blood);
        }

        // GET: Blood/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Blood == null)
            {
                return NotFound();
            }

            var blood = await _context.Blood
                .FirstOrDefaultAsync(m => m.bTubeid == id);
            if (blood == null)
            {
                return NotFound();
            }

            return View(blood);
        }

        // POST: Blood/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Blood == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Blood'  is null.");
            }
            var blood = await _context.Blood.FindAsync(id);
            if (blood != null)
            {
                _context.Blood.Remove(blood);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodExists(int id)
        {
          return (_context.Blood?.Any(e => e.bTubeid == id)).GetValueOrDefault();
        }
    }
}
