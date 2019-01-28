using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
    public class AmenityController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public AmenityController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: Amenity
        public async Task<IActionResult> Index()
        {
            return View(await _context.Amenity.ToListAsync());
        }

        // GET: Amenity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenity = await _context.Amenity
                .FirstOrDefaultAsync(m => m.ID == id);
            if (amenity == null)
            {
                return NotFound();
            }

            return View(amenity);
        }

        // GET: Amenity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description")] Amenity amenity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amenity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amenity);
        }

        // GET: Amenity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenity = await _context.Amenity.FindAsync(id);
            if (amenity == null)
            {
                return NotFound();
            }
            return View(amenity);
        }

        // POST: Amenity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description")] Amenity amenity)
        {
            if (id != amenity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amenity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenityExists(amenity.ID))
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
            return View(amenity);
        }

        // GET: Amenity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenity = await _context.Amenity
                .FirstOrDefaultAsync(m => m.ID == id);
            if (amenity == null)
            {
                return NotFound();
            }

            return View(amenity);
        }

        // POST: Amenity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amenity = await _context.Amenity.FindAsync(id);
            _context.Amenity.Remove(amenity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmenityExists(int id)
        {
            return _context.Amenity.Any(e => e.ID == id);
        }
    }
}
