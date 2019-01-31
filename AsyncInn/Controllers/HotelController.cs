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

        public HotelController(IHotel context)
        {
            _context = context;
        }

        // GET: Hotel
        public IActionResult Index(string searchString)
        {
            var searchResults = from hotel in _context.GetHotels()
                                select hotel;
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

        // GET: Hotel/Details/5
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

        // GET: Hotel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,Phone,City,State,Country")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateHotel(hotel);
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotel/Edit/5
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

        // POST: Hotel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Hotel/Delete/5
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

        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = _context.GetHotels().FirstOrDefault(m => m.ID == id);
            await _context.DeleteHotel(hotel);
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
            return _context.GetHotels().Any(e => e.ID == id);
        }
    }
}
