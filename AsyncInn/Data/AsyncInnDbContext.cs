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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // set composite key
            modelBuilder.Entity<CourseEnrollments>().HasKey(ce => new { ce.CourseID, ce.StudentID });

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Hotel AAA",
                    Phone = 0001112222,
                    Address = "",
                    City = "",
                    State = State.AL,
                    Country = Country.Canada
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Hotel BBB",
                    Phone = 1112223333,
                    Address = "",
                    City = "",
                    State = State.AL,
                    Country = Country.Mexico
                }, 
                new Hotel
                {
                    ID = 3,
                    Name = "Hotel CCC",
                    Phone = 1112221111,
                    Address = "",
                    City = "",
                    State = State.AL,
                    Country = Country.Mexico
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Hotel DDD",
                    Phone = 2223332222,
                    Address = "",
                    City = "",
                    State = State.AL,
                    Country = Country.United_States
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Hotel EEE",
                    Phone = 3334443333,
                    Address = "",
                    City = "",
                    State = State.AL,
                    Country = Country.United_States
                }
                );

            modelBuilder.Entity<RoomPlan>().HasData(
                new RoomPlan
                {
                    ID = 1,
                    Layout = Layout.Studio,
                },
                new RoomPlan
                {
                    ID = 2,
                    Layout = Layout.Studio,
                },
                new RoomPlan
                {
                    ID = 3,
                    Layout = Layout.OneBedroom,
                },
                new RoomPlan
                {
                    ID = 4,
                    Layout = Layout.OneBedroom,
                },
                new RoomPlan
                {
                    ID = 5,
                    Layout = Layout.TwoBedroom,
                },
                new RoomPlan
                {
                    ID = 6,
                    Layout = Layout.TwoBedroom,
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

        // Add DB tables
        public DbSet<Amenity> Amenity { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<RoomConfig> RoomConfig { get; set; }
        public DbSet<RoomPlan> RoomPlan { get; set; }
    }
}
