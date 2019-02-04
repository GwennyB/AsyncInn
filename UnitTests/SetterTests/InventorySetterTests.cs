using System;
using Xunit;
using AsyncInn.Models;


namespace UnitTests.SetterTests
{
    public class InventorySetterTests
    {
        /// <summary>
        /// verifies setter for Inventory.RoomNumber
        /// </summary>
        [Fact]
        public void Inventory_CanSetRoomNumber()
        {
            Inventory room = new Inventory();
            room.RoomNumber = 400;
            room.RoomNumber = 200;
            Assert.Equal(200, room.RoomNumber);
        }

        /// <summary>
        /// verifies setter for Inventory.Rate
        /// </summary>
        [Fact]
        public void Inventory_CanSetRate()
        {
            Inventory room = new Inventory();
            room.Rate = 200M;
            room.Rate = 100M;
            Assert.Equal(100M, room.Rate);
        }

        /// <summary>
        /// verifies setter for Inventory.PetsOK
        /// </summary>
        [Fact]
        public void Inventory_CanSetPetsOK()
        {
            Inventory room = new Inventory();
            room.PetsOK = true;
            room.PetsOK = false;
            Assert.False(room.PetsOK);
        }

        /// <summary>
        /// verifies setter for Inventory.RoomName
        /// </summary>
        [Fact]
        public void Inventory_CanSetRoomName()
        {
            Inventory room = new Inventory();
            room.RoomName = "teststring";
            room.RoomName = "newstring";
            Assert.Equal("newstring", room.RoomName);
        }

        /// <summary>
        /// verifies setter for Inventory.HotelID
        /// </summary>
        [Fact]
        public void Inventory_CanSetHotelID()
        {
            Inventory room = new Inventory();
            room.HotelID = 4;
            room.HotelID = 5;
            Assert.Equal(5, room.HotelID);
        }

        /// <summary>
        /// verifies setter for Inventory.Hotel
        /// </summary>
        [Fact]
        public void Inventory_CanSetHotel()
        {
            Inventory room = new Inventory();
            Hotel hotel = new Hotel();
            room.Hotel = hotel;
            Hotel hotelTwo = new Hotel();
            room.Hotel = hotelTwo;
            Assert.Equal(hotelTwo, room.Hotel);
        }

        /// <summary>
        /// verifies setter for Inventory.RoomPlanID
        /// </summary>
        [Fact]
        public void Inventory_CanSetRoomPlanID()
        {
            Inventory room = new Inventory();
            RoomPlan roomPlan = new RoomPlan();
            roomPlan.Layout = Layout.Studio;
            RoomPlan roomPlanTwo = new RoomPlan();
            room.RoomPlan = roomPlanTwo;
            Assert.Equal(roomPlanTwo, room.RoomPlan);
        }
    }
}