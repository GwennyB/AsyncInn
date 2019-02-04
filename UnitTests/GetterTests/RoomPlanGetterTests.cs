using System;
using Xunit;
using AsyncInn;
using AsyncInn.Models;
using System.Collections.Generic;

namespace UnitTests.GetterTests
{
    public class RoomPlanGetterTests
    {
        /// <summary>
        /// verifies getter for RoomPlan.ID
        /// </summary>
        [Fact]
        public void RoomPlan_CanGetID()
        {
            RoomPlan roomplan = new RoomPlan();
            roomplan.ID = 1;
            Assert.Equal(1, roomplan.ID);
        }

        /// <summary>
        /// verifies getter for RoomPlan.Layout
        /// </summary>
        [Fact]
        public void RoomPlan_CanGetLayout()
        {
            RoomPlan roomplan = new RoomPlan();
            roomplan.Layout = Layout.Studio;
            Assert.Equal(Layout.Studio, roomplan.Layout);
        }

        /// <summary>
        /// verifies getter for RoomPlan.RoomType
        /// </summary>
        [Fact]
        public void RoomPlan_CanGetRoomType()
        {
            RoomPlan roomplan = new RoomPlan();
            roomplan.RoomType = "teststring";
            Assert.Equal("teststring", roomplan.RoomType);
        }

        /// <summary>
        /// verifies getter for RoomPlan.RoomConfigGroup
        /// </summary>
        [Fact]
        public void RoomPlan_CanGetRoomConfigGroup()
        {
            RoomPlan roomPlan = new RoomPlan();
            roomPlan.RoomConfigGroup = new List<RoomConfig>();
            roomPlan.RoomConfigGroup.Add(new RoomConfig());
            roomPlan.RoomConfigGroup.Add(new RoomConfig());
            roomPlan.RoomConfigGroup.Add(new RoomConfig());
            Assert.Equal(3, roomPlan.RoomConfigGroup.Count);
        }

    }
}
