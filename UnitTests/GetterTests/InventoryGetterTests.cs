using System;
using Xunit;
using AsyncInn.Models;


namespace UnitTests.GetterTests
{
    public class InventoryGetterTests
    {
        /// <summary>
        /// verifies getter for Inventory.RoomNumber
        /// </summary>
        [Fact]
        public void Inventory_CanGetRoomNumber()
        {
            Inventory room = new Inventory();
            room.RoomNumber = 400;
            Assert.Equal(400, room.RoomNumber);
        }

        /// <summary>
        /// verifies getter for Inventory.Rate
        /// </summary>
        [Fact]
        public void Inventory_CanGetRate()
        {
            Inventory room = new Inventory();
            room.Rate = 200M;
            Assert.Equal(200M, room.Rate);
        }

        /// <summary>
        /// verifies getter for Inventory.PetsOK
        /// </summary>
        [Fact]
        public void Inventory_CanGetPetsOK()
        {
            Inventory room = new Inventory();
            room.PetsOK = true;
            Assert.True(room.PetsOK);
        }

        /// <summary>
        /// verifies getter for Inventory.RoomName
        /// </summary>
        [Fact]
        public void Inventory_CanGetRoomName()
        {
            Inventory room = new Inventory();
            room.RoomName = "teststring";
            Assert.Equal("teststring", room.RoomName);
        }

        /// <summary>
        /// verifies getter for Inventory.HotelID
        /// </summary>
        [Fact]
        public void Inventory_CanGetHotelID()
        {
            Inventory room = new Inventory();
            room.HotelID = 4;
            Assert.Equal(4, room.HotelID);
        }

        /// <summary>
        /// verifies getter for Inventory.Hotel
        /// </summary>
        [Fact]
        public void Inventory_CanGetHotel()
        {
            Inventory room = new Inventory();
            Hotel hotel = new Hotel();
            room.Hotel = hotel;
            Assert.Equal(hotel, room.Hotel);
        }

        /// <summary>
        /// verifies getter for Inventory.RoomPlanID
        /// </summary>
        [Fact]
        public void Inventory_CanGetRoomPlanID()
        {
            Inventory room = new Inventory();
            RoomPlan roomPlan = new RoomPlan();
            room.RoomPlan = roomPlan;
            Assert.Equal(roomPlan, room.RoomPlan);
        }
    }
}
