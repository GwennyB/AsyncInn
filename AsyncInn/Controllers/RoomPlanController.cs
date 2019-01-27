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

        public RoomPlanController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: RoomPlan
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomPlan.ToListAsync());
        }

        // GET: RoomPlan/Details/5
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

        // GET: RoomPlan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomPlan/Create
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

        // GET: RoomPlan/Edit/5
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

        // POST: RoomPlan/Edit/5
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

        // GET: RoomPlan/Delete/5
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

        // POST: RoomPlan/Delete/5
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
