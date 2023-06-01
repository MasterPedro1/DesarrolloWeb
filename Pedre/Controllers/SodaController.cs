using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pedre.Models;

namespace Pedre.Controllers
{
    public class SodaController : Controller
    {
        private readonly MvcSodaContext _context;

        public SodaController(MvcSodaContext context)
        {
            _context = context;
        }

        // GET: Soda
        public async Task<IActionResult> Index()
        {
              return View(await _context.Soda.ToListAsync());
        }

        // GET: Soda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Soda == null)
            {
                return NotFound();
            }

            var soda = await _context.Soda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soda == null)
            {
                return NotFound();
            }

            return View(soda);
        }

        // GET: Soda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Soda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Realese,Name,Flavor,Price")] Soda soda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soda);
        }

        // GET: Soda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Soda == null)
            {
                return NotFound();
            }

            var soda = await _context.Soda.FindAsync(id);
            if (soda == null)
            {
                return NotFound();
            }
            return View(soda);
        }

        // POST: Soda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Realese,Name,Flavor,Price")] Soda soda)
        {
            if (id != soda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SodaExists(soda.Id))
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
            return View(soda);
        }

        // GET: Soda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Soda == null)
            {
                return NotFound();
            }

            var soda = await _context.Soda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soda == null)
            {
                return NotFound();
            }

            return View(soda);
        }

        // POST: Soda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Soda == null)
            {
                return Problem("Entity set 'MvcSodaContext.Soda'  is null.");
            }
            var soda = await _context.Soda.FindAsync(id);
            if (soda != null)
            {
                _context.Soda.Remove(soda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SodaExists(int id)
        {
          return _context.Soda.Any(e => e.Id == id);
        }
    }
}
