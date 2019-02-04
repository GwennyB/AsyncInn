using System;
using Xunit;
using AsyncInn.Models;
using System.Collections.Generic;

namespace UnitTests.SetterTests
{
    public class AmenitySetterTests
    {
        /// <summary>
        /// verifies setter for Amenity.ID
        /// </summary>
        [Fact]
        public void Amenity_CanSetID()
        {
            Amenity amenity = new Amenity();
            amenity.ID = 1;
            amenity.ID = 2;
            Assert.Equal(2, amenity.ID);
        }

        /// <summary>
        /// verifies setter for Amenity.Description
        /// </summary>
        [Fact]
        public void Amenity_CanSetDescription()
        {
            Amenity amenity = new Amenity();
            amenity.Description = "newstring";
            Assert.Equal("newstring", amenity.Description);
        }
    }
}
