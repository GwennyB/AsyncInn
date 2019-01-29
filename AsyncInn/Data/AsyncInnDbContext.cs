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

            // DB seed data
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Hotel AAA",
                    Phone = 0001112222,
                    Address = "100 Main St",
                    City = "Austin",
                    State = State.TX,
                    Country = Country.United_States
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Hotel BBB",
                    Phone = 1112223333,
                    Address = "200 Main St",
                    City = "Birmingham",
                    State = State.AL,
                    Country = Country.United_States
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Hotel CCC",
                    Phone = 1112221111,
                    Address = "300 Main St",
                    City = "Cancun",
                    State = State.none,
                    Country = Country.Mexico
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Hotel DDD",
                    Phone = 2223332222,
                    Address = "400 Main St",
                    City = "Vancouver",
                    State = State.none,
                    Country = Country.Canada
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Hotel EEE",
                    Phone = 3334443333,
                    Address = "500 Main St",
                    City = "Toronto",
                    State = State.none,
                    Country = Country.Canada
                }
                );

            modelBuilder.Entity<RoomPlan>().HasData(
                new RoomPlan
                {
                    ID = 1,
                    Layout = Layout.Studio,
                    RoomType = "Studio A"
                },
                new RoomPlan
                {
                    ID = 2,
                    Layout = Layout.Studio,
                    RoomType = "Studio B"
                },
                new RoomPlan
                {
                    ID = 3,
                    Layout = Layout.OneBedroom,
                    RoomType = "One Bedroom A"
                },
                new RoomPlan
                {
                    ID = 4,
                    Layout = Layout.OneBedroom,
                    RoomType = "One Bedroom B"
                },
                new RoomPlan
                {
                    ID = 5,
                    Layout = Layout.TwoBedroom,
                    RoomType = "Two Bedroom A"
                },
                new RoomPlan
                {
                    ID = 6,
                    Layout = Layout.TwoBedroom,
                    RoomType = "Two Bedroom B"
                }
                );

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity
                {
                    ID = 1,
                    Description = "coffee maker",
                },
                new Amenity
                {
                    ID = 2,
                    Description = "mini bar",
                },
                new Amenity
                {
                    ID = 3,
                    Description = "refrigerator",
                },
                new Amenity
                {
                    ID = 4,
                    Description = "air conditioning",
                },
                new Amenity
                {
                    ID = 5,
                    Description = "charging station",
                }
                );


        }


        // Add database tables
        public DbSet<Amenity> Amenity { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<RoomConfig> RoomConfig { get; set; }
        public DbSet<RoomPlan> RoomPlan { get; set; }
    }
}
