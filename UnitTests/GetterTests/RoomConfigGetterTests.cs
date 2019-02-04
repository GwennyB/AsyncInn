using System;
using Xunit;
using AsyncInn.Models;


namespace UnitTests.GetterTests
{
    public class RoomConfigGetterTests
    {
        /// <summary>
        /// verifies getter for RoomConfig.RoomPlanID
        /// </summary>
        [Fact]
        public void RoomConfig_CanGetRoomPlanID()
        {
            RoomConfig roomConfig = new RoomConfig();
            roomConfig.RoomPlanID = 1;
            Assert.Equal(1, roomConfig.RoomPlanID);
        }

        /// <summary>
        /// verifies getter for RoomConfig.AmenityID
        /// </summary>
        [Fact]
        public void RoomConfig_CanGetAmenityID()
        {
            RoomConfig roomConfig = new RoomConfig();
            roomConfig.AmenityID = 1;
            Assert.Equal(1, roomConfig.AmenityID);
        }

        /// <summary>
        /// verifies getter for RoomConfig.RoomPlan
        /// </summary>
        [Fact]
        public void RoomConfig_CanGetRoomPlan()
        {
            RoomConfig roomConfig = new RoomConfig();
            RoomPlan roomPlan = new RoomPlan();
            roomConfig.RoomPlan = roomPlan;
            Assert.Equal(roomPlan, roomConfig.RoomPlan);
        }

        /// <summary>
        /// verifies getter for RoomConfig.Amenity
        /// </summary>
        [Fact]
        public void RoomConfig_CanGetAmenity()
        {
            RoomConfig roomConfig = new RoomConfig();
            Amenity amenity = new Amenity();
            amenity.ID = 5;
            roomConfig.Amenity = amenity;
            Assert.Equal(5, roomConfig.Amenity.ID);
        }
    }
}
