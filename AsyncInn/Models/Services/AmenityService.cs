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
        private AsyncInnDbContext _context;

        /// <summary>
        /// creates database context
        /// </summary>
        public AmenityService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// adds a new row to the Amenity table
        /// </summary>
        /// <param name="amenity"> new Amenity to add </param>
        /// <returns> completed task </returns>
        public async Task CreateAmenity(Amenity amenity)
        {
            _context.Amenity.Add(amenity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// gets all rows in Amenity table
        /// </summary>
        /// <returns> list of Amenities </returns>
        public List<Amenity> GetAmenities()
        {
            return _context.Amenity.ToList<Amenity>();
        }

        /// <summary>
        /// updates a row in the Amenity table
        /// </summary>
        /// <param name="amenity"> Amenity to update </param>
        /// <returns> completed task </returns>
        public async Task UpdateAmenity(Amenity amenity)
        {
            _context.Amenity.Update(amenity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// deletes a row in Amenity table
        /// </summary>
        /// <param name="amenity"> Amenity to delete </param>
        /// <returns> completed task </returns>
        public async Task DeleteAmenity(Amenity amenity)
        {
            _context.Amenity.Remove(amenity);
            await _context.SaveChangesAsync();
        }

    }
}
