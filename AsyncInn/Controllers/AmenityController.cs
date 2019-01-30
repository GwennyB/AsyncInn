using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    public class AmenityController : Controller
    {
        private readonly IAmenity _context;

        public AmenityController(IAmenity context)
        {
            _context = context;
        }

        // GET: Amenity
        public IActionResult Index()
        {
            return View(_context.GetAmenities());
        }

        // GET: Amenity/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenity = _context.GetAmenities()
                .FirstOrDefault(m => m.ID == id);
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
                await _context.CreateAmenity(amenity);
                return RedirectToAction(nameof(Index));
            }
            return View(amenity);
        }

        // GET: Amenity/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenity = _context.GetAmenities().FirstOrDefault(m => m.ID == id);
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
                    await _context.UpdateAmenity(amenity);
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenity = _context.GetAmenities()
                .FirstOrDefault(m => m.ID == id);
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
            var amenity = _context.GetAmenities().FirstOrDefault(m => m.ID == id);
            await _context.DeleteAmenity(amenity);
            return RedirectToAction(nameof(Index));
        }

        private bool AmenityExists(int id)
        {
            return _context.GetAmenities().Any(e => e.ID == id);
        }
    }
}
