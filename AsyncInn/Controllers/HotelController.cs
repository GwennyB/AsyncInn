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
    public class HotelController : Controller
    {
        private readonly IHotel _context;

        /// <summary>
        /// sets database context to _context field
        /// </summary>
        public HotelController(IHotel context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Hotel
        /// gets all (filtered) rows and sends to Client in Index view
        /// </summary>
        /// <param name="searchString"> filtering criterion </param>
        /// <returns> populated Index view </returns>
        public async Task<IActionResult> Index(string searchString)
        {
            var searchResults = from hotel in _context.GetHotels()
                                select hotel;
            foreach(Hotel hotel in searchResults)
            {
                hotel.HotelInventory = await _context.GetHotelInventory(hotel.ID);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                searchResults = searchResults.Where(s => 
                    s.Name.ToLower().Contains(searchString.ToLower()) ||
                    s.Address.ToLower().Contains(searchString.ToLower()) ||
                    s.City.ToLower().Contains(searchString.ToLower())
                    );
                return View(searchResults);
            }
            return View(_context.GetHotels());
        }

        /// <summary>
        /// GET: Hotel/Details/5
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

            var hotel = _context.GetHotels()
                .FirstOrDefault(m => m.ID == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        /// <summary>
        /// GET: Hotel/Create
        /// loads Create page
        /// </summary>
        /// <returns> Create view </returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Hotel/Create
        /// adds 'hotel' to table as new row
        /// </summary>
        /// <param name="hotel"> hotel to add </param>
        /// <returns> populated Index view with new row shown (or Delete view with 'hotel' details populated if model errors exist) </returns>
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,Phone,City,State,Country")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateHotel(hotel);
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        /// <summary>
        /// GET: Hotel/Edit/5
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

            var hotel = _context.GetHotels().FirstOrDefault(m => m.ID == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        /// <summary>
        /// POST: Hotel/Edit/5
        /// updates table with details in 'hotel'
        /// </summary>
        /// <param name="id"> ID of hotel to update </param>
        /// <param name="hotel"> hotel details to use for update </param>
        /// <returns>Index view populated with all records (including update), or NotFound error page (if 'id' not found), or Edit view with 'hotel' populated (if model errors exist)</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,Phone,City,State,Country")] Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateHotel(hotel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.ID))
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
            return View(hotel);
        }

        /// <summary>
        /// GET: Hotel/Delete/5
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

            var hotel = _context.GetHotels()
                .FirstOrDefault(m => m.ID == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        /// <summary>
        /// POST: Hotel/Delete/5
        /// deletes 'id' row from table
        /// </summary>
        /// <param name="id"> ID of row to delete </param>
        /// <returns> Index view showing updated list of rows </returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = _context.GetHotels().FirstOrDefault(m => m.ID == id);
            await _context.DeleteHotel(hotel);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// HELPER: confirms existence of row by ID
        /// </summary>
        /// <param name="id"> ID of row to confirm </param>
        /// <returns> true if present, false if not </returns>
        private bool HotelExists(int id)
        {
            return _context.GetHotels().Any(e => e.ID == id);
        }
    }
}
