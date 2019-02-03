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
    public class RoomPlanController : Controller
    {
        private readonly IRoomPlan _context;

        /// <summary>
        /// sets database context to _context field
        /// </summary>
        /// <param name="context"></param>
        public RoomPlanController(IRoomPlan context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: RoomPlans
        /// gets all (filtered) RoomPlans and sends to Client in Index view
        /// </summary>
        /// <param name="searchString"> filter criterion </param>
        /// <returns> populated Index view </returns>
        public async Task<IActionResult> Index(string searchString)
        {
            var searchResults = from roomPlan in _context.GetRoomPlans()
                                select roomPlan;
            foreach (RoomPlan roomPlan in searchResults)
            {
                roomPlan.RoomConfigGroup = await _context.GetRoomConfigGroup(roomPlan.ID);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                searchResults = searchResults.Where(s =>
                    s.RoomType.ToLower().Contains(searchString.ToLower())
                    );
                return View(searchResults);
            }
            return View(_context.GetRoomPlans());
        }

        /// <summary>
        /// GET: RoomPlans/Details/5 
        /// gets row 'id' and sends to Client in Details view
        /// </summary>
        /// <param name="id"> ID of row to show </param>
        /// <returns> populated Details view (or NotFound error view) </returns>
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomPlan = _context.GetRoomPlans().FirstOrDefault(m => m.ID == id);
            if (roomPlan == null)
            {
                return NotFound();
            }

            return View(roomPlan);
        }

        /// <summary>
        /// GET: RoomPlans/Create
        /// loads Create page
        /// </summary>
        /// <returns> Create view </returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: RoomPlans/Create
        /// adds 'roomPlan' to table as new row
        /// </summary>
        /// <param name="roomPlan"> RoomPlan to add </param>
        /// <returns> populated Index view with new row shown (or Delete view with 'roomPlan' details populated if model errors exist) </returns>
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID,Layout,RoomType")] RoomPlan roomPlan)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateRoomPlan(roomPlan);
                return RedirectToAction(nameof(Index));
            }
            return View(roomPlan);
        }

        /// <summary>
        /// GET: RoomPlans/Edit/5
        /// gets a specific row from table 
        /// </summary>
        /// <param name="id"> ID of row to get </param>
        /// <returns> Edit view with detail populated for row 'id' </returns>
        public IActionResult Edit(int id)
        {
            var roomPlan = _context.GetRoomPlans().FirstOrDefault(m => m.ID == id);
            if (roomPlan == null)
            {
                return NotFound();
            }
            return View(roomPlan);
        }

        /// <summary>
        /// POST: RoomPlans/Edit/5
        /// updates table with details in 'roomPlan'
        /// </summary>
        /// <param name="id"> ID of RoomPlan to update </param>
        /// <param name="roomPlan"> roomPlan details to use for update </param>
        /// <returns>Index view populated with all records (including update), or NotFound error page (if 'id' not found), or Edit view with 'roomPlan' populated (if model errors exist)</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Layout")] RoomPlan roomPlan)
        {
            if (id != roomPlan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateRoomPlan(roomPlan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomPlanExists(roomPlan.ID))
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
            return View(roomPlan);
        }

        /// <summary>
        /// GET: RoomPlans/Delete/5
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

            var roomPlan = _context.GetRoomPlans()
                .FirstOrDefault(m => m.ID == id);
            if (roomPlan == null)
            {
                return NotFound();
            }

            return View(roomPlan);
        }

        /// <summary>
        /// POST: RoomPlans/Delete/5
        /// deletes 'id' row from table
        /// </summary>
        /// <param name="id"> ID of row to delete </param>
        /// <returns> Index view showing updated list of rows </returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomPlan = _context.GetRoomPlans().FirstOrDefault(m => m.ID == id);
            await _context.DeleteRoomPlan(roomPlan);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// HELPER: confirms existence of row by ID
        /// </summary>
        /// <param name="id"> ID of row to confirm </param>
        /// <returns> true if present, false if not </returns>
        private bool RoomPlanExists(int id)
        {
            return _context.GetRoomPlans().Any(e => e.ID == id);
        }
    }
}
