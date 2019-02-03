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
    public class InventoryController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public InventoryController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: Inventory
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.Inventory.Include(i => i.Hotel).Include(i => i.RoomPlan);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: Inventory/Details/5
        public async Task<IActionResult> Details(int HotelID, int RoomNumber)
        {
            if (HotelID < 1 || RoomNumber < 1)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .Include(i => i.Hotel)
                .Include(i => i.RoomPlan)
                .FirstOrDefaultAsync(m => m.HotelID == HotelID && m.RoomNumber == RoomNumber);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventory/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Name");
            ViewData["RoomPlanID"] = new SelectList(_context.RoomPlan, "ID", "RoomType");
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("ID,RoomNumber,Rate,PetsOK,HotelID,RoomPlanID,RoomName")] Inventory inventory)
        {
            var checkDupe = await _context.Inventory.FirstOrDefaultAsync(room => room.RoomNumber == inventory.RoomNumber && room.HotelID == inventory.HotelID);
            if(checkDupe != null)
            {
                return View(checkDupe);
            }
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Name", inventory.HotelID);
            ViewData["RoomPlanID"] = new SelectList(_context.RoomPlan, "ID", "RoomType", inventory.RoomPlanID);
            return View(inventory);
        }

        // GET: Inventory/Edit/5
        public async Task<IActionResult> Edit(int HotelID, int RoomNumber)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var inventory = await _context.Inventory.FirstOrDefaultAsync(room => room.HotelID == HotelID && room.RoomNumber == RoomNumber);
            if (inventory == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Name", inventory.HotelID);
            ViewData["RoomPlanID"] = new SelectList(_context.RoomPlan, "ID", "RoomType", inventory.RoomPlanID);
            return View(inventory);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Edit(int HotelID, int RoomNumber, [Bind("ID,RoomNumber,Rate,PetsOK,HotelID,RoomPlanID")] Inventory inventory)
        {
            //if (id != inventory.HotelID)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.HotelID))
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
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Name", inventory.HotelID);
            ViewData["RoomPlanID"] = new SelectList(_context.RoomPlan, "ID", "RoomType", inventory.RoomPlanID);
            return View(inventory);
        }

        // GET: Inventory/Delete/5
        public async Task<IActionResult> Delete(int HotelID, int RoomNumber)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var inventory = await _context.Inventory
                .Include(i => i.Hotel)
                .Include(i => i.RoomPlan)
                .FirstOrDefaultAsync(room => room.HotelID == HotelID && room.RoomNumber == RoomNumber);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(int HotelID, int RoomNumber)
        {
            var inventory = await _context.Inventory.FirstOrDefaultAsync(room => room.HotelID == HotelID && room.RoomNumber == RoomNumber);
        _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.HotelID == id);
        }
    }
}
