using System;
using Xunit;
using AsyncInn.Models;


namespace UnitTests.SetterTests
{
    public class HotelSetterTests
    {        
        /// <summary>
        /// verifies setter for Hotel.ID
        /// </summary>
        [Fact]
        public void Hotel_CanSetID()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 10;
            hotel.ID = 1;
            Assert.Equal(1, hotel.ID);
        }

        /// <summary>
        /// verifies setter for Hotel.Name
        /// </summary>
        [Fact]
        public void Hotel_CanSetName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "teststring";
            hotel.Name = "newstring";
            Assert.Equal("newstring", hotel.Name);
        }

        /// <summary>
        /// verifies setter for Hotel.Address
        /// </summary>
        [Fact]
        public void Hotel_CanSetAddress()
        {
            Hotel hotel = new Hotel();
            hotel.Address = "teststring";
            hotel.Address = "newstring";
            Assert.Equal("newstring", hotel.Address);
        }

        /// <summary>
        /// verifies setter for Hotel.Phone
        /// </summary>
        [Fact]
        public void Hotel_CanSetPhone()
        {
            Hotel hotel = new Hotel();
            hotel.Phone = 1234567890;
            hotel.Phone = 1111111111;
            Assert.Equal(1111111111, hotel.Phone);
        }

        /// <summary>
        /// verifies setter for Hotel.City
        /// </summary>
        [Fact]
        public void Hotel_CanSetCity()
        {
            Hotel hotel = new Hotel();
            hotel.City = "teststring";
            hotel.City = "newstring";
            Assert.Equal("newstring", hotel.City);
        }

        /// <summary>
        /// verifies setter for Hotel.State
        /// </summary>
        [Fact]
        public void Hotel_CanSetState()
        {
            Hotel hotel = new Hotel();
            hotel.State = State.CA;
            hotel.State = State.TX;
            Assert.Equal(State.TX, hotel.State);
        }

        /// <summary>
        /// verifies setter for Hotel.Country
        /// </summary>
        [Fact]
        public void Hotel_CanSetCountry()
        {
            Hotel hotel = new Hotel();
            hotel.Country = Country.Mexico;
            hotel.Country = Country.Canada;
            Assert.Equal(Country.Canada, hotel.Country);
        }
    }
}
