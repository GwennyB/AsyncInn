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
        // insert context
        private AsyncInnDbContext _context;

        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }


        // create
        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
        }

        // read
        public List<Hotel> GetHotels()
        {
            return _context.Hotel.ToList<Hotel>();
        }

        // read
        public async Task<List<Inventory>> GetHotelInventory(int id)
        {
            return await _context.Inventory.Where(i => i.HotelID == id).ToListAsync<Inventory>();
        }

        // update
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotel.Update(hotel);
            await _context.SaveChangesAsync();
        }

        // delete
        public async Task DeleteHotel(Hotel hotel)
        {
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
        }


    }
}
