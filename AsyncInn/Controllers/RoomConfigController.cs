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
    public class RoomConfigController : Controller
    {
        private readonly AsyncInnDbContext _context;

        /// <summary>
        /// sets database context to _context field
        /// </summary>
        public RoomConfigController(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: RoomConfig
        /// gets all (filtered) rows and sends to Client in Index view
        /// </summary>
        /// <param name="searchString"> filter criterion </param>
        /// <returns> populated Index view </returns>
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.RoomConfig.Include(r => r.Amenity).Include(r => r.RoomPlan);
            return View(await asyncInnDbContext.ToListAsync());
        }

        /// <summary>
        /// GET: RoomConfig/Create
        /// loads Create page
        /// </summary>
        /// <returns> Create view </returns>
        public IActionResult Create()
        {
            ViewData["AmenityID"] = new SelectList(_context.Amenity, "ID", "Description");
            ViewData["RoomPlanID"] = new SelectList(_context.RoomPlan, "ID", "RoomType");
            //ViewData["RoomConfigGroup"] = new SelectList(_context.RoomConfig, "HotelID", "AmenityID");
            return View();
        }

        /// <summary>
        /// POST: RoomPlans/Create
        /// adds row to table and loads
        /// </summary>
        /// <param name="roomConfig"> RoomPlan to add </param>
        /// <returns> populated Index view with new row shown (or Delete view with new row data populated if model errors exist) </returns>
        [HttpPost]
        public async Task<IActionResult> Create([Bind("RoomPlanID,AmenityID")] RoomConfig roomConfig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomConfig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenityID"] = new SelectList(_context.Amenity, "ID", "Description", roomConfig.AmenityID);
            ViewData["RoomPlanID"] = new SelectList(_context.RoomPlan, "ID", "RoomType", roomConfig.RoomPlanID);
            return View(roomConfig);
        }

        /// <summary>
        /// GET: RoomConfig/Delete/5
        /// loads Delete confirmation page with details shown for 'id'
        /// </summary>
        /// <param name="id"> ID of row to delete </param>
        /// <returns> 'Delete' confirmation page with 'id' loaded, or NotFound error if not found or none selected </returns>
        public async Task<IActionResult> Delete(int RoomPlanID, int AmenityID)
        {
            if (RoomPlanID < 1 || AmenityID < 1)
            {
                return NotFound();
            }

            var roomConfig = await _context.RoomConfig
                .Include(r => r.Amenity)
                .Include(r => r.RoomPlan)
                .FirstOrDefaultAsync(m => m.RoomPlanID == RoomPlanID && m.AmenityID == AmenityID);

            if (roomConfig == null)
            {
                return NotFound();
            }

            return View(roomConfig);
        }

        /// <summary>
        /// POST: RoomConfig/Delete/5
        /// deletes 'id' row from table
        /// </summary>
        /// <param name="id"> ID of row to delete </param>
        /// <returns> Index view showing updated list of rows </returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int RoomPlanID, int AmenityID)
        {
            var roomConfig = await _context.RoomConfig.FirstOrDefaultAsync(m => m.RoomPlanID == RoomPlanID && m.AmenityID == AmenityID);
            _context.RoomConfig.Remove(roomConfig);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// HELPER: confirms existence of row by ID
        /// </summary>
        /// <param name="id"> ID of row to confirm </param>
        /// <returns> true if present, false if not </returns>
        private bool RoomConfigExists(int id)
        {
            return _context.RoomConfig.Any(e => e.RoomPlanID == id);
        }
    }
}
