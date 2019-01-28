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
    public class RoomPlanController : Controller
    {
        private readonly AsyncInnDbContext _context;

        /// <summary>
        /// build controller object
        /// </summary>
        /// <param name="context"></param>
        public RoomPlanController(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: RoomPlan/Index
        /// </summary>
        /// <returns> RoomPlan view loaded with RoomPlan table data </returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomPlan.ToListAsync());
        }

        /// <summary>
        /// GET: RoomPlan/Details/{id}
        /// </summary>
        /// <param name="id"> RoomPlan row ID number </param>
        /// <returns> RoomPlan view loaded with RoomPlan table data (single row) </returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomPlan = await _context.RoomPlan
                .FirstOrDefaultAsync(m => m.ID == id);
            if (roomPlan == null)
            {
                return NotFound();
            }

            return View(roomPlan);
        }

        /// <summary>
        /// GET: RoomPlan/Create
        /// </summary>
        /// <returns> RoomPlan/Create view </returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: RoomPlan/Create
        /// </summary>
        /// <param name="roomPlan"> RoomPlan object </param>
        /// <returns> RoomPlan/Create view loaded with single RoomPlan object </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Layout")] RoomPlan roomPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomPlan);
        }

        /// <summary>
        /// GET: RoomPlan/Delete/5
        /// </summary>
        /// <param name="id"> RoomPlan row ID number </param>
        /// <returns> RoomPlan/Delete view loaded with chosen RoomPlan object </returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomPlan = await _context.RoomPlan
                .FirstOrDefaultAsync(m => m.ID == id);
            if (roomPlan == null)
            {
                return NotFound();
            }

            return View(roomPlan);
        }

        /// <summary>
        /// POST: RoomPlan/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns> redirect to RoomPlan Index </returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomPlan = await _context.RoomPlan.FindAsync(id);
            _context.RoomPlan.Remove(roomPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// checks whether a RoomPlan exists in DB
        /// </summary>
        /// <param name="id"> ID of RoomPlan to check </param>
        /// <returns> true if exists, false if not </returns>
        private bool RoomPlanExists(int id)
        {
            return _context.RoomPlan.Any(e => e.ID == id);
        }
    }
}
