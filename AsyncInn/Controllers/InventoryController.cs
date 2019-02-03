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

        /// <summary>
        /// sets database context to _context field
        /// </summary>
        public InventoryController(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Inventory
        /// gets all (filtered) rows and sends to Client in Index view
        /// </summary>
        /// <returns> populated Index view </returns>
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.Inventory.Include(i => i.Hotel).Include(i => i.RoomPlan);
            return View(await asyncInnDbContext.ToListAsync());
        }

        /// <summary>
        /// GET: Inventory/Details/5
        /// gets row 'id' and sends to Client in Details view
        /// </summary>
        /// <param name="id"> ID of row to show </param>
        /// <returns> populated Details view (or NotFound error view) </returns>
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

        /// <summary>
        /// GET: Inventory/Create
        /// loads Create page
        /// </summary>
        /// <returns> Create view </returns>
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotel, "ID", "Name");
            ViewData["RoomPlanID"] = new SelectList(_context.RoomPlan, "ID", "RoomType");
            return View();
        }

        /// <summary>
        /// POST: Inventory/Create
        /// adds 'inventory' to table as new row
        /// </summary>
        /// <param name="inventory"> RoomPlan to add </param>
        /// <returns> populated Index view with new row shown (or Delete view with 'inventory' details populated if model errors exist) </returns>
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

        /// <summary>
        /// GET: Inventory/Edit/5
        /// gets a specific row from table 
        /// </summary>
        /// <param name="HotelID"> HotelID of row to get </param>
        /// <param name="roomNumber"> RoomNumber of row to get </param>
        /// <returns> Edit view with detail populated for row 'id' </returns>
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

        /// <summary>
        /// POST: Inventory/Edit/5
        /// updates table with details in 'inventory'
        /// </summary>
        /// <param name="HotelID"> HotelID of row to update </param>
        /// <param name="RoomNumber"> RoomNumber of row to update </param>
        /// <param name="inventory"> inventory details to use for update </param>
        /// <returns> Index view populated with all records (including update), or NotFound error page (if row not found), or Edit view with 'inventory' populated (if model errors exist) </returns>
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

        /// <summary>
        /// GET: Inventory/Delete/5
        /// loads Delete confirmation page with details shown for specified record
        /// </summary>
        /// <param name="HotelID"> HotelID of row to delete </param>
        /// <param name="RoomNumber"> RoomNumber of row to delete </param>
        /// <returns> 'Delete' confirmation page with 'id' loaded, or NotFound error if not found or none selected </returns>
        public async Task<IActionResult> Delete(int HotelID, int RoomNumber)
        {
            if (HotelID < 1 || RoomNumber < 1)
            {
                return NotFound();
            }

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

        /// <summary>
        /// POST: Inventory/Delete/5
        /// deletes specified row from table
        /// </summary>
        /// <param name="HotelID"> HotelID of row to delete </param>
        /// <param name="RoomNumber"> RoomNumber of row to delete </param>
        /// <returns> Index view showing updated list of rows </returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int HotelID, int RoomNumber)
        {
            var inventory = await _context.Inventory.FirstOrDefaultAsync(room => room.HotelID == HotelID && room.RoomNumber == RoomNumber);
        _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// HELPER: confirms existence of row by ID
        /// </summary>
        /// <param name="id"> ID of row to confirm </param>
        /// <returns> true if present, false if not </returns>
        private bool InventoryExists(int HotelID, int RoomNumber)
        {
            return _context.Inventory.Any(e => e.HotelID == HotelID && e.RoomNumber == RoomNumber);
        }
    }
}
