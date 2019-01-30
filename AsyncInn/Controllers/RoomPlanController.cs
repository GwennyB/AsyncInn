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

        public RoomPlanController(IRoomPlan context)
        {
            _context = context;
        }

        // GET: RoomPlans
        public IActionResult Index()
        {
            return View(_context.GetRoomPlans());
        }

        // GET: RoomPlans/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: RoomPlans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: RoomPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomPlan = await _context.RoomPlan.FindAsync(id);
            if (roomPlan == null)
            {
                return NotFound();
            }
            return View(roomPlan);
        }

        // POST: RoomPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    _context.Update(roomPlan);
                    await _context.SaveChangesAsync();
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

        // GET: RoomPlans/Delete/5
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

        // POST: RoomPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomPlan = await _context.RoomPlan.FindAsync(id);
            _context.RoomPlan.Remove(roomPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomPlanExists(int id)
        {
            return _context.RoomPlan.Any(e => e.ID == id);
        }
    }
}
