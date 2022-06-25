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
    public class BloodBankController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloodBankController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BloodBank
        public async Task<IActionResult> Index()
        {
              return _context.BloodBank != null ? 
                          View(await _context.BloodBank.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BloodBank'  is null.");
        }

        // GET: BloodBank/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BloodBank == null)
            {
                return NotFound();
            }

            var bloodBank = await _context.BloodBank
                .FirstOrDefaultAsync(m => m.bbId == id);
            if (bloodBank == null)
            {
                return NotFound();
            }

            return View(bloodBank);
        }

        // GET: BloodBank/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BloodBank/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bbId,bbName,bbAddress")] BloodBank bloodBank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloodBank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bloodBank);
        }

        // GET: BloodBank/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BloodBank == null)
            {
                return NotFound();
            }

            var bloodBank = await _context.BloodBank.FindAsync(id);
            if (bloodBank == null)
            {
                return NotFound();
            }
            return View(bloodBank);
        }

        // POST: BloodBank/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bbId,bbName,bbAddress")] BloodBank bloodBank)
        {
            if (id != bloodBank.bbId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodBank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodBankExists(bloodBank.bbId))
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
            return View(bloodBank);
        }

        // GET: BloodBank/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BloodBank == null)
            {
                return NotFound();
            }

            var bloodBank = await _context.BloodBank
                .FirstOrDefaultAsync(m => m.bbId == id);
            if (bloodBank == null)
            {
                return NotFound();
            }

            return View(bloodBank);
        }

        // POST: BloodBank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BloodBank == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BloodBank'  is null.");
            }
            var bloodBank = await _context.BloodBank.FindAsync(id);
            if (bloodBank != null)
            {
                _context.BloodBank.Remove(bloodBank);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodBankExists(int id)
        {
          return (_context.BloodBank?.Any(e => e.bbId == id)).GetValueOrDefault();
        }
    }
}
