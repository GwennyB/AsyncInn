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

        /// <summary>
        /// sets database context to _context field
        /// </summary>
        public AmenityController(IAmenity context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Amenity
        /// gets all (filtered) rows and sends to Client in Index view
        /// </summary>
        /// <param name="searchString"> filtering criterion </param>
        /// <returns> populated Index view </returns>
        public IActionResult Index(string searchString)
        {
            var searchResults = from roomPlan in _context.GetAmenities()
                                select roomPlan;
            if (!String.IsNullOrEmpty(searchString))
            {
                searchResults = searchResults.Where(s =>
                    s.Description.ToLower().Contains(searchString.ToLower())
                    );
                return View(searchResults);
            }
            return View(_context.GetAmenities());
        }

        ///// <summary>
        ///// GET: Amenity/Details/5
        ///// gets row 'id' and sends to Client in Details view
        ///// </summary>
        ///// <param name="id"> ID of row to show </param>
        ///// <returns> populated Details view (or NotFound error view) </returns>
        //public IActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var amenity = _context.GetAmenities()
        //        .FirstOrDefault(m => m.ID == id);
        //    if (amenity == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(amenity);
        //}

        /// <summary>
        /// GET: Amenity/Create
        /// loads Create page
        /// </summary>
        /// <returns> Create view </returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Amenity/Create
        /// adds 'amenity' to table as new row
        /// </summary>
        /// <param name="amenity"> amenity to add </param>
        /// <returns> populated Index view with new row shown (or Delete view with 'amenity' details populated if model errors exist) </returns>
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID,Description")] Amenity amenity)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateAmenity(amenity);
                return RedirectToAction(nameof(Index));
            }
            return View(amenity);
        }

        /// <summary>
        /// GET: HoAmenitytel/Edit/5
        /// gets a specific row from table 
        /// </summary>
        /// <param name="id"> ID of row to get </param>
        /// <returns> Edit view with detail populated for row 'id' </returns>
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

        /// <summary>
        /// POST: Amenity/Edit/5
        /// updates table with details in 'amenity'
        /// </summary>
        /// <param name="id"> ID of amenity to update </param>
        /// <param name="amenity"> amenity details to use for update </param>
        /// <returns>Index view populated with all records (including update), or NotFound error page (if 'id' not found), or Edit view with 'amenity' populated (if model errors exist)</returns>
        [HttpPost]
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

        /// <summary>
        /// GET: Amenity/Delete/5
        /// loads Delete confirmation page with details shown for 'id'
        /// </summary>
        /// <param name="id"> ID of row to delete </param>
        /// <returns> 'Delete' confirmation page with 'id' loaded, or NotFound error if not found or none selected </returns>
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

        /// <summary>
        /// POST: Amenity/Delete/5
        /// deletes 'id' row from table
        /// </summary>
        /// <param name="id"> ID of row to delete </param>
        /// <returns> Index view showing updated list of rows </returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amenity = _context.GetAmenities().FirstOrDefault(m => m.ID == id);
            await _context.DeleteAmenity(amenity);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// HELPER: confirms existence of row by ID
        /// </summary>
        /// <param name="id"> ID of row to confirm </param>
        /// <returns> true if present, false if not </returns>
        private bool AmenityExists(int id)
        {
            return _context.GetAmenities().Any(e => e.ID == id);
        }
    }
}
