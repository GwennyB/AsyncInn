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

        public RoomConfigController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: RoomConfig
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.RoomConfig.Include(r => r.Amenity).Include(r => r.RoomPlan);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: RoomConfig/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomConfig = await _context.RoomConfig
                .Include(r => r.Amenity)
                .Include(r => r.RoomPlan)
                .FirstOrDefaultAsync(m => m.RoomPlanID == id);
            if (roomConfig == null)
            {
                return NotFound();
            }

            return View(roomConfig);
        }

        // GET: RoomConfig/Create
        public IActionResult Create()
        {
            ViewData["AmenityID"] = new SelectList(_context.Amenity, "Description", "Description");
            ViewData["RoomPlanID"] = new SelectList(_context.RoomPlan, "ID", "ID");
            ViewData["RoomConfigGroup"] = new SelectList(_context.RoomConfig, "ID", "ID");
            return View();
        }

        // POST: RoomConfig/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomPlanID,AmenityID")] RoomConfig roomConfig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomConfig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenityID"] = new SelectList(_context.Amenity, "ID", "ID", roomConfig.AmenityID);
            ViewData["RoomPlanID"] = new SelectList(_context.RoomPlan, "ID", "ID", roomConfig.RoomPlanID);
            return View(roomConfig);
        }

        // GET: RoomConfig/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomConfig = await _context.RoomConfig.FindAsync(id);
            if (roomConfig == null)
            {
                return NotFound();
            }
            ViewData["AmenityID"] = new SelectList(_context.Amenity, "ID", "ID", roomConfig.AmenityID);
            ViewData["RoomPlanID"] = new SelectList(_context.RoomPlan, "ID", "ID", roomConfig.RoomPlanID);
            return View(roomConfig);
        }

        // POST: RoomConfig/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomPlanID,AmenityID")] RoomConfig roomConfig)
        {
            if (id != roomConfig.RoomPlanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomConfig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomConfigExists(roomConfig.RoomPlanID))
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
            ViewData["AmenityID"] = new SelectList(_context.Amenity, "ID", "ID", roomConfig.AmenityID);
            ViewData["RoomPlanID"] = new SelectList(_context.RoomPlan, "ID", "ID", roomConfig.RoomPlanID);
            return View(roomConfig);
        }

        // GET: RoomConfig/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomConfig = await _context.RoomConfig
                .Include(r => r.Amenity)
                .Include(r => r.RoomPlan)
                .FirstOrDefaultAsync(m => m.RoomPlanID == id);
            if (roomConfig == null)
            {
                return NotFound();
            }

            return View(roomConfig);
        }

        // POST: RoomConfig/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomConfig = await _context.RoomConfig.FindAsync(id);
            _context.RoomConfig.Remove(roomConfig);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomConfigExists(int id)
        {
            return _context.RoomConfig.Any(e => e.RoomPlanID == id);
        }
    }
}
