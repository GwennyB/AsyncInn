using System;
using Xunit;
using AsyncInn.Models;


namespace UnitTests.GetterTests
{
    public class AmenityGetterTests
    {
        /// <summary>
        /// verifies getter for Amenity.ID
        /// </summary>
        [Fact]
        public void Amenity_CanGetID()
        {
            Amenity amenity = new Amenity();
            amenity.ID = 1;
            Assert.Equal(1, amenity.ID);
        }

        /// <summary>
        /// verifies getter for Amenity.Description
        /// </summary>
        [Fact]
        public void Amenity_CanGetDescription()
        {
            Amenity amenity = new Amenity();
            amenity.Description = "teststring";
            Assert.Equal("teststring", amenity.Description);
        }
    }
}
