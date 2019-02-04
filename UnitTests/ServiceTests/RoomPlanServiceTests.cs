using System;
using Xunit;
using AsyncInn;
using AsyncInn.Models;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AsyncInn.Models.Services;
using System.Collections.Generic;

namespace UnitTests.RouteTests
{
    public class RoomPlanServiceTests
    {
        /// <summary>
        /// verifies CreateRoomPlan creates a new RoomPlan record
        /// </summary>
        [Fact]
        public async void CanCreateRoomPlan()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateRoomPlan").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                var dumpList = context.RoomPlan.ToList();
                foreach (RoomPlan item in dumpList)
                {
                    context.RoomPlan.Remove(item);
                }
                RoomPlan roomPlan = new RoomPlan();
                roomPlan.ID = 100;
                roomPlan.Layout = Layout.Studio;
                roomPlan.RoomType = "roomtype";

                // Act
                RoomPlanService service = new RoomPlanService(context);
                await service.CreateRoomPlan(roomPlan);
                var result = await context.RoomPlan.FirstOrDefaultAsync(s => s.ID == 100);
                // Assert
                Assert.Equal(roomPlan, result);
            }
        }

        /// <summary>
        /// verifies GetRoomPlans returns a list of RoomPlans
        /// </summary>
        [Fact]
        public async void CanGetRoomPlans()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateRoomPlan").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                var dumpList = context.RoomPlan.ToList();
                foreach (RoomPlan item in dumpList)
                {
                    context.RoomPlan.Remove(item);
                }
                RoomPlan roomPlanOne = new RoomPlan();
                roomPlanOne.ID = 100;
                roomPlanOne.Layout = Layout.Studio;
                roomPlanOne.RoomType = "roomtype";

                RoomPlan roomPlanTwo = new RoomPlan();
                roomPlanTwo.ID = 101;
                roomPlanTwo.Layout = Layout.Studio;
                roomPlanTwo.RoomType = "roomtype";

                List<RoomPlan> roomPlans = new List<RoomPlan>();
                roomPlans.Add(roomPlanOne);
                roomPlans.Add(roomPlanTwo);

                // Act
                RoomPlanService service = new RoomPlanService(context);
                await service.CreateRoomPlan(roomPlanOne);
                await service.CreateRoomPlan(roomPlanTwo);
                var result = service.GetRoomPlans();
                // Assert
                Assert.Equal(roomPlans, result);
            }
        }

        /// <summary>
        /// verifies GetHotelInventory returns a list of rooms
        /// </summary>
        [Fact]
        public async void CanGetRoomConfigGroup()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                var dumpList = context.RoomPlan.ToList();
                foreach (RoomPlan item in dumpList)
                {
                    context.RoomPlan.Remove(item);
                }
                var dumpListTwo = context.RoomConfig.ToList();
                foreach (RoomConfig item in dumpListTwo)
                {
                    context.RoomConfig.Remove(item);
                }
                RoomPlan roomPlanOne = new RoomPlan();
                roomPlanOne.ID = 100;
                roomPlanOne.Layout = Layout.Studio;
                roomPlanOne.RoomType = "roomtype";

                Amenity amenityOne = new Amenity();
                amenityOne.ID = 100;
                amenityOne.Description = "desc";
                Amenity amenityTwo = new Amenity();
                amenityTwo.ID = 101;
                amenityTwo.Description = "desc";
                context.Amenity.Add(amenityOne);
                context.Amenity.Add(amenityTwo);
                List<RoomConfig> roomConfigs = new List<RoomConfig>();
                RoomConfig roomConfigOne = new RoomConfig();
                roomConfigOne.RoomPlanID = 100;
                roomConfigOne.AmenityID = 100;
                RoomConfig roomConfigTwo = new RoomConfig();
                roomConfigTwo.RoomPlanID = 100;
                roomConfigTwo.AmenityID = 101;

                // Act
                RoomPlanService service = new RoomPlanService(context);
                await service.CreateRoomPlan(roomPlanOne);
                var result = await service.GetRoomConfigGroup(roomPlanOne.ID);
                // Assert
                Assert.Equal(roomConfigs, result);
            }
        }

        /// <summary>
        /// verifies UpdateRoomPlan updates the RoomPlan record
        /// </summary>
        [Fact]
        public async void CanUpdateRoomPlan()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateRoomPlan").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                var dumpList = context.RoomPlan.ToList();
                foreach (RoomPlan item in dumpList)
                {
                    context.RoomPlan.Remove(item);
                }
                RoomPlan roomPlanOne = new RoomPlan();
                roomPlanOne.ID = 100;
                roomPlanOne.Layout = Layout.Studio;
                roomPlanOne.RoomType = "roomtype";
                RoomPlanService service = new RoomPlanService(context);
                await service.CreateRoomPlan(roomPlanOne);

                // Act
                roomPlanOne.Layout = Layout.OneBedroom;
                await service.UpdateRoomPlan(roomPlanOne);
                var result = service.GetRoomPlans().FirstOrDefault(s => s.ID == roomPlanOne.ID);
                // Assert
                Assert.Equal(Layout.OneBedroom, result.Layout);
            }
        }

        /// <summary>
        /// verifies DeleteRoomPlan deletes the RoomPlan record
        /// </summary>
        [Fact]
        public async void CanDeleteRoomPlan()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateRoomPlan").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                var dumpList = context.RoomPlan.ToList();
                foreach (RoomPlan item in dumpList)
                {
                    context.RoomPlan.Remove(item);
                }
                RoomPlan roomPlanOne = new RoomPlan();
                roomPlanOne.ID = 100;
                roomPlanOne.Layout = Layout.Studio;
                roomPlanOne.RoomType = "roomtype";
                RoomPlanService service = new RoomPlanService(context);
                await service.CreateRoomPlan(roomPlanOne);

                // Act
                await service.DeleteRoomPlan(roomPlanOne);
                var result = service.GetRoomPlans().FirstOrDefault(s => s.ID == roomPlanOne.ID);
                // Assert
                Assert.Null(result);
            }
        }
    }
}
