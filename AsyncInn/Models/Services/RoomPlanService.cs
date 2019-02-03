using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomPlanService : IRoomPlan
    {
        private AsyncInnDbContext _context;

        /// <summary>
        /// creates database context
        /// </summary>
        public RoomPlanService(AsyncInnDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// adds a new row to RoomPlan table
        /// </summary>
        /// <param name="roomPlan"> definition for new row </param>
        /// <returns> completed task </returns>
        public async Task CreateRoomPlan(RoomPlan roomPlan)
        {
            _context.RoomPlan.Add(roomPlan);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// gets all rows in RoomPlan table
        /// </summary>
        /// <returns> list of RoomPlans</returns>
        public List<RoomPlan> GetRoomPlans()
        {
            return _context.RoomPlan.ToList<RoomPlan>();
        }

        /// <summary>
        /// gets all rows in RoomConfig table associated with RoomPlan ID
        /// </summary>
        /// <param name="id"> RoomPlan ID to find </param>
        /// <returns> list of RoomConfigs associated with 'id' </returns>
        public async Task<List<RoomConfig>> GetRoomConfigGroup(int id)
        {
            return await _context.RoomConfig.Where(i => i.RoomPlanID == id).ToListAsync<RoomConfig>();
        }

        /// <summary>
        /// updates a row in RoomPlan table
        /// </summary>
        /// <param name="roomPlan"> RoomPlan to update </param>
        /// <returns> completed task</returns>
        public async Task UpdateRoomPlan(RoomPlan roomPlan)
        {
            _context.RoomPlan.Update(roomPlan);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// deletes a row in RoomPlan table
        /// </summary>
        /// <param name="roomPlan"> RoomPlan to delete </param>
        /// <returns> completed task </returns>
        public async Task DeleteRoomPlan(RoomPlan roomPlan)
        {
            _context.RoomPlan.Remove(roomPlan);
            await _context.SaveChangesAsync();
        }
    }
}

//// Add database tables
//public DbSet<Amenity> Amenity { get; set; }
//public DbSet<Hotel> Hotel { get; set; }
//public DbSet<Inventory> Inventory { get; set; }
//public DbSet<RoomConfig> RoomConfig { get; set; }
//public DbSet<RoomPlan> RoomPlan { get; set; }
