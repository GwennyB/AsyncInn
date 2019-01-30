using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenityService : IAmenity
    {
        // insert context
        private AsyncInnDbContext _context;

        public AmenityService(AsyncInnDbContext context)
        {
            _context = context;
        }


        // create
        public async Task CreateAmenity(Amenity amenity)
        {
            _context.Amenity.Add(amenity);
            await _context.SaveChangesAsync();
        }

        // read
        public List<Amenity> GetAmenities()
        {
            return _context.Amenity.ToList<Amenity>();
        }

        // update
        public async Task UpdateAmenity(Amenity amenity)
        {
            _context.Amenity.Update(amenity);
            await _context.SaveChangesAsync();
        }

        // delete
        public async Task DeleteAmenity(Amenity amenity)
        {
            _context.Amenity.Remove(amenity);
            await _context.SaveChangesAsync();
        }

    }
}
