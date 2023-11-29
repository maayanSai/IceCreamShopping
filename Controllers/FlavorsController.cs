using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IceCreamsShopping.Data;
using IceCreamsShopping.Models;

namespace IceCreamsShopping.Controllers
{
    public class FlavorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlavorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Flavors
        public async Task<IActionResult> Index()
        {
              return _context.Flavors != null ? 
                          View(await _context.Flavors.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Flavors'  is null.");
        }

        // GET: Flavors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Flavors == null)
            {
                return NotFound();
            }

            var flavors = await _context.Flavors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flavors == null)
            {
                return NotFound();
            }

            return View(flavors);
        }

        // GET: Flavors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flavors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageUrl")] Flavors flavors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flavors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flavors);
        }

        // GET: Flavors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Flavors == null)
            {
                return NotFound();
            }

            var flavors = await _context.Flavors.FindAsync(id);
            if (flavors == null)
            {
                return NotFound();
            }
            return View(flavors);
        }

        // POST: Flavors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageUrl")] Flavors flavors)
        {
            if (id != flavors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flavors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlavorsExists(flavors.Id))
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
            return View(flavors);
        }

        // GET: Flavors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Flavors == null)
            {
                return NotFound();
            }

            var flavors = await _context.Flavors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flavors == null)
            {
                return NotFound();
            }

            return View(flavors);
        }

        // POST: Flavors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Flavors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Flavors'  is null.");
            }
            var flavors = await _context.Flavors.FindAsync(id);
            if (flavors != null)
            {
                _context.Flavors.Remove(flavors);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlavorsExists(int id)
        {
          return (_context.Flavors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
