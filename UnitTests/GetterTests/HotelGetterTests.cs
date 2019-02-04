using System;
using Xunit;
using AsyncInn.Models;


namespace UnitTests.GetterTests
{
    public class HotelGetterTests
    {
        /// <summary>
        /// verifies getter for Hotel.ID
        /// </summary>
        [Fact]
        public void Hotel_CanGetID()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 10;
            Assert.Equal(10, hotel.ID);
        }

        /// <summary>
        /// verifies getter for Hotel.Name
        /// </summary>
        [Fact]
        public void Hotel_CanGetName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "teststring";
            Assert.Equal("teststring", hotel.Name);
        }

        /// <summary>
        /// verifies getter for Hotel.Address
        /// </summary>
        [Fact]
        public void Hotel_CanGetAddress()
        {
            Hotel hotel = new Hotel();
            hotel.Address = "teststring";
            Assert.Equal("teststring", hotel.Address);
        }

        /// <summary>
        /// verifies getter for Hotel.Phone
        /// </summary>
        [Fact]
        public void Hotel_CanGetPhone()
        {
            Hotel hotel = new Hotel();
            hotel.Phone = 1234567890;
            Assert.Equal(1234567890, hotel.Phone);
        }

        /// <summary>
        /// verifies getter for Hotel.City
        /// </summary>
        [Fact]
        public void Hotel_CanGetCity()
        {
            Hotel hotel = new Hotel();
            hotel.City = "teststring";
            Assert.Equal("teststring", hotel.City);
        }

        /// <summary>
        /// verifies getter for Hotel.State
        /// </summary>
        [Fact]
        public void Hotel_CanGetState()
        {
            Hotel hotel = new Hotel();
            hotel.State = State.CA;
            Assert.Equal(State.CA, hotel.State);
        }

        /// <summary>
        /// verifies getter for Hotel.Country
        /// </summary>
        [Fact]
        public void Hotel_CanGetCountry()
        {
            Hotel hotel = new Hotel();
            hotel.Country = Country.Mexico;
            Assert.Equal(Country.Mexico, hotel.Country);
        }
    }
}
