using System;
using Xunit;
using AsyncInn;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using System.Linq;
using AsyncInn.Models.Services;
using System.Collections.Generic;

namespace UnitTests.RouteTests
{
    public class AmenityServiceTests
    {
        /// <summary>
        /// verifies CreateAmenity creates a new Amenity record
        /// </summary>
        [Fact]
        public async void CanCreateAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                var dumpList = context.Amenity.ToList();
                foreach (Amenity item in dumpList)
                {
                    context.Amenity.Remove(item);
                }
                Amenity amenity = new Amenity();
                amenity.ID = 100;
                amenity.Description = "description";

                // Act
                AmenityService service = new AmenityService(context);
                await service.CreateAmenity(amenity);
                var result = await context.Amenity.FirstOrDefaultAsync(s => s.ID == amenity.ID);
                // Assert
                Assert.Equal(amenity, result);
            }
        }

        /// <summary>
        /// verifies GetAmenitiess returns a list of Amenitys
        /// </summary>
        [Fact]
        public async void CanGetAmenitiess()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                var dumpList = context.Amenity.ToList();
                foreach (Amenity item in dumpList)
                {
                    context.Amenity.Remove(item);
                }
                Amenity amenityOne = new Amenity();
                amenityOne.ID = 100;
                amenityOne.Description = "description";

                Amenity amenityTwo = new Amenity();
                amenityTwo.ID = 101;
                amenityTwo.Description = "description";

                List<Amenity> amenities = new List<Amenity>();
                amenities.Add(amenityOne);
                amenities.Add(amenityTwo);

                // Act
                AmenityService service = new AmenityService(context);
                await service.CreateAmenity(amenityOne);
                await service.CreateAmenity(amenityTwo);
                var result = service.GetAmenities();
                // Assert
                Assert.Equal(amenities, result);
            }
        }

        /// <summary>
        /// verifies UpdateAmenity updates the Amenity record
        /// </summary>
        [Fact]
        public async void CanUpdateAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                var dumpList = context.Amenity.ToList();
                foreach (Amenity item in dumpList)
                {
                    context.Amenity.Remove(item);
                }
                Amenity amenityOne = new Amenity();
                amenityOne.ID = 100;
                amenityOne.Description = "description";
                AmenityService service = new AmenityService(context);
                await service.CreateAmenity(amenityOne);

                // Act
                amenityOne.Description = "teststring";
                await service.UpdateAmenity(amenityOne);
                var result = service.GetAmenities().FirstOrDefault(s => s.ID == amenityOne.ID);
                // Assert
                Assert.Equal("teststring", result.Description);
            }
        }

        /// <summary>
        /// verifies DeleteAmenity deletes the Amenity record
        /// </summary>
        [Fact]
        public async void CanDeleteAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                var dumpList = context.Amenity.ToList();
                foreach (Amenity item in dumpList)
                {
                    context.Amenity.Remove(item);
                }
                Amenity amenityOne = new Amenity();
                amenityOne.ID = 100;
                amenityOne.Description = "description";
                AmenityService service = new AmenityService(context);
                await service.CreateAmenity(amenityOne);

                // Act
                await service.DeleteAmenity(amenityOne);
                var result = service.GetAmenities().FirstOrDefault(s => s.ID == amenityOne.ID);
                // Assert
                Assert.Null(result);
            }
        }
    }
}
