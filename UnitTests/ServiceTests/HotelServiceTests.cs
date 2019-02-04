using System;
using Xunit;
using AsyncInn;
using AsyncInn.Models;
using AsyncInn.Models.Services;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace UnitTests.RouteTests
{
    public class HotelServiceTests
    {
        /// <summary>
        /// verifies CreateHotel creates a hotel
        /// </summary>
        [Fact]
        public async void CanCreateHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Hotel hotel = new Hotel();
                hotel.ID = 100;
                hotel.Name = "name";
                hotel.Address = "address";
                hotel.Phone = 2223334444;
                hotel.City = "city";
                hotel.State = State.ID;
                hotel.Country = Country.United_States;
                // Act
                HotelService service = new HotelService(context);
                await service.CreateHotel(hotel);
                var result = context.Hotel.FirstOrDefault(s => s.ID == hotel.ID);
                // Assert
                Assert.Equal(hotel, result);
            }
        }

        /// <summary>
        /// verifies GetHotels returns a list of hotels
        /// </summary>
        [Fact]
        public async void CanGetHotels()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                var dumpList = context.Hotel.ToList(); 
                foreach (Hotel item in dumpList)
                {
                    context.Hotel.Remove(item);
                }
                Hotel hotel = new Hotel();
                hotel.ID = 101;
                hotel.Name = "name";
                hotel.Address = "address";
                hotel.Phone = 2223334444;
                hotel.City = "city";
                hotel.State = State.ID;
                hotel.Country = Country.United_States;

                Hotel hotelTwo = new Hotel();
                hotelTwo.ID = 102;
                hotelTwo.Name = "name";
                hotelTwo.Address = "address";
                hotelTwo.Phone = 2223334444;
                hotelTwo.City = "city";
                hotelTwo.State = State.ID;
                hotelTwo.Country = Country.United_States;

                List<Hotel> hotels = new List<Hotel>();
                hotels.Add(hotel);
                hotels.Add(hotelTwo);

                // Act
                HotelService service = new HotelService(context);
                await service.CreateHotel(hotel);
                await service.CreateHotel(hotelTwo);
                var result = service.GetHotels();
                // Assert
                Assert.Equal(hotels, result);
            }
        }

        /// <summary>
        /// verifies GetHotelInventory returns a list of rooms
        /// </summary>
        [Fact]
        public async void CanGetHotelInventory()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                var dumpList = context.Hotel.ToList();
                foreach (Hotel item in dumpList)
                {
                    context.Hotel.Remove(item);
                }
                var dumpListTwo = context.Inventory.ToList();
                foreach (Inventory item in dumpListTwo)
                {
                    context.Inventory.Remove(item);
                }
                Hotel hotel = new Hotel();
                hotel.ID = 103;
                hotel.Name = "name";
                hotel.Address = "address";
                hotel.Phone = 2223334444;
                hotel.City = "city";
                hotel.State = State.ID;
                hotel.Country = Country.United_States;

                Inventory roomOne = new Inventory();
                roomOne.HotelID = 103;
                roomOne.RoomNumber = 200;
                Inventory roomTwo = new Inventory();
                roomTwo.HotelID = 103;
                roomTwo.RoomNumber = 100;
                List<Inventory> roomsList = new List<Inventory>();
                roomsList.Add(roomOne);
                roomsList.Add(roomTwo);
                context.Inventory.Add(roomOne);
                context.Inventory.Add(roomTwo);

                // Act
                HotelService service = new HotelService(context);
                await service.CreateHotel(hotel);
                var result = await service.GetHotelInventory(hotel.ID);
                // Assert
                Assert.Equal(roomsList, result);
            }
        }

        /// <summary>
        /// verifies UpdateHotel updates the hotel record
        /// </summary>
        [Fact]
        public async void CanUpdateHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                var dumpList = context.Hotel.ToList();
                foreach (Hotel item in dumpList)
                {
                    context.Hotel.Remove(item);
                }
                Hotel hotel = new Hotel();
                hotel.ID = 104;
                hotel.Name = "name";
                hotel.Address = "address";
                hotel.Phone = 2223334444;
                hotel.City = "city";
                hotel.State = State.ID;
                hotel.Country = Country.United_States;
                HotelService service = new HotelService(context);
                await service.CreateHotel(hotel);

                // Act
                hotel.Name = "newname";
                await service.UpdateHotel(hotel);
                var result = service.GetHotels().FirstOrDefault(s => s.ID == 104);
                // Assert
                Assert.Equal("newname", result.Name);
            }
        }

        /// <summary>
        /// verifies DeleteHotel deletes the hotel record
        /// </summary>
        [Fact]
        public async void CanDeleteHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                var dumpList = context.Hotel.ToList();
                foreach (Hotel item in dumpList)
                {
                    context.Hotel.Remove(item);
                }
                Hotel hotel = new Hotel();
                hotel.ID = 105;
                hotel.Name = "name";
                hotel.Address = "address";
                hotel.Phone = 2223334444;
                hotel.City = "city";
                hotel.State = State.ID;
                hotel.Country = Country.United_States;
                HotelService service = new HotelService(context);
                await service.CreateHotel(hotel);

                // Act
                await service.DeleteHotel(hotel);
                var result = service.GetHotels().FirstOrDefault(s => s.ID == hotel.ID);
                // Assert
                Assert.Null(result);
            }
        }
    }
}
