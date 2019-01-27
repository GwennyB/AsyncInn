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

        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Build composite key for amenity groups
            modelBuilder.Entity<RoomConfig>().HasKey(ce => new { ce.RoomPlanID, ce.AmenityID });
            // Build composite key for inventory IDs
            modelBuilder.Entity<Inventory>().HasKey(ce => new { ce.HotelID, ce.RoomNumber });
        }

        // Add DB tables
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Inventory> RoomInventory { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RoomConfig> RoomConfigs { get; set; }
        public DbSet<RoomPlan> RoomPlans { get; set; }
    }
}
