using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        /// <summary>
        /// builds derived DbContext
        /// </summary>
        /// <param name="options"></param>
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// overrides (DbContext virtual) method that builds out basic API structure
        /// maps composite keys
        /// </summary>
        /// <param name="modelBuilder">  </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Build composite key for amenity groups
            modelBuilder.Entity<RoomConfig>().HasKey(ce => new { ce.RoomPlanID, ce.AmenityID });
            // Build composite key for inventory IDs
            modelBuilder.Entity<Inventory>().HasKey(ce => new { ce.HotelID, ce.RoomNumber });
        }

        // Add DB tables
        public DbSet<Amenity> Amenity { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<RoomConfig> RoomConfig { get; set; }
        public DbSet<RoomPlan> RoomPlan { get; set; }
    }
}
