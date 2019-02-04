using System;
using Xunit;
using AsyncInn.Models;


namespace UnitTests.SetterTests
{
    public class RoomConfigSetterTests
    {
        /// <summary>
        /// verifies setter for RoomConfig.RoomPlanID
        /// </summary>
        [Fact]
        public void RoomConfig_CanSetRoomPlanID()
        {
            RoomConfig roomConfig = new RoomConfig();
            roomConfig.RoomPlanID = 1;
            roomConfig.RoomPlanID = 3;
            Assert.Equal(3, roomConfig.RoomPlanID);
        }

        /// <summary>
        /// verifies setter for RoomConfig.AmenityID
        /// </summary>
        [Fact]
        public void RoomConfig_CanSetAmenityID()
        {
            RoomConfig roomConfig = new RoomConfig();
            roomConfig.AmenityID = 1;
            roomConfig.AmenityID = 3;
            Assert.Equal(3, roomConfig.AmenityID);
        }

        /// <summary>
        /// verifies setter for RoomConfig.RoomPlan
        /// </summary>
        [Fact]
        public void RoomConfig_CanSetRoomPlan()
        {
            RoomConfig roomConfig = new RoomConfig();
            RoomPlan roomPlan = new RoomPlan();
            roomConfig.RoomPlan = roomPlan;
            RoomPlan roomPlanTwo = new RoomPlan();
            roomConfig.RoomPlan = roomPlanTwo;
            Assert.Equal(roomPlanTwo, roomConfig.RoomPlan);
        }

        /// <summary>
        /// verifies setter for RoomConfig.Amenity
        /// </summary>
        [Fact]
        public void RoomConfig_CanSetAmenity()
        {
            RoomConfig roomConfig = new RoomConfig();
            Amenity amenity = new Amenity();
            roomConfig.Amenity = amenity;
            Amenity amenityTwo = new Amenity();
            roomConfig.Amenity = amenityTwo;
            Assert.Equal(amenityTwo, roomConfig.Amenity);
        }
    }
}
