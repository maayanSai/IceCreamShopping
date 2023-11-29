using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IceCreamsShopping.Data;
using IceCreamsShopping.Models;
using IceCreamsShopping.ApiService;

namespace IceCreamsShopping.Controllers
{
    public class FlavorsManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlavorsManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FlavorsManager
        public async Task<IActionResult> Index()
        {
              return _context.Flavors != null ? 
                          View(await _context.Flavors.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Flavors'  is null.");
        }

        // GET: FlavorsManager/Details/5
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

        // GET: FlavorsManager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlavorsManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageUrl")] Flavors flavors)
        {

            if (ModelState.IsValid)
            {
                //Call the CheckImage action to check if the image contains ice cream.
                //var containsIceCream = await CheckImage(flavors.ImageUrl);
                //if (containsIceCream)
                //{
                    // If the image contains ice cream, proceed to save the product.
                    _context.Add(flavors);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                //}
                //else
                //{
                //    // Handle the case where the image doesn't contain ice cream.
                //    ModelState.AddModelError("ImageUrl", "The image does not contain ice cream.");
                //}
            }
            return View(flavors);

        }



        // GET: FlavorsManager/Edit/5
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

        // POST: FlavorsManager/Edit/5
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

        // GET: FlavorsManager/Delete/5
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

        // POST: FlavorsManager/Delete/5
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

        //private async Task<bool> CheckImage(string imageUrl)
        //{
        //    var _apiServices = new ApiServices("acc_85435d24acba976");
        //    var answer = await _apiServices.CallServiceApi<bool>($"http://localhost:5103/api/imagga?imageUrl={Uri.EscapeDataString(imageUrl)}");
        //    return answer;
        //}
    }
}
