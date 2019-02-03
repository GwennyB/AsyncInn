using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelService : IHotel
    {
        private AsyncInnDbContext _context;

        /// <summary>
        /// creates database context
        /// </summary>
        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// adds a new row to Hotel table
        /// </summary>
        /// <param name="hotel"> new hotel to add </param>
        /// <returns> completed task </returns>
        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// gets all rows in Hotel table
        /// </summary>
        /// <returns> list of Hotels </returns>
        public List<Hotel> GetHotels()
        {
            return _context.Hotel.ToList<Hotel>();
        }

        /// <summary>
        /// gets all rows in Inventory table associated with Hotel ID
        /// </summary>
        /// <param name="id"> Hotel ID to find </param>
        /// <returns> list of Inventory associated with 'id' </returns>
        public async Task<List<Inventory>> GetHotelInventory(int id)
        {
            return await _context.Inventory.Where(i => i.HotelID == id).ToListAsync<Inventory>();
        }

        /// <summary>
        /// updates a row in Hotel table
        /// </summary>
        /// <param name="hotel"> Hotel to update </param>
        /// <returns> completed task </returns>
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotel.Update(hotel);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// deletes a row in Hotel table
        /// </summary>
        /// <param name="hotel"> Hotel to delete </param>
        /// <returns> completed task </returns>
        public async Task DeleteHotel(Hotel hotel)
        {
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
        }


    }
}
