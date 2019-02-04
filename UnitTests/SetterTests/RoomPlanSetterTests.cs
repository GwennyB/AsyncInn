using System;
using Xunit;
using AsyncInn.Models;
using System.Collections.Generic;

namespace UnitTests.SetterTests
{
    public class RoomPlanSetterTests
    {
        /// <summary>
        /// verifies setter for RoomPlan.ID
        /// </summary>
        [Fact]
        public void RoomPlan_CanSetID()
        {
            RoomPlan roomplan = new RoomPlan();
            roomplan.ID = 1;
            roomplan.ID = 2;
            Assert.Equal(2, roomplan.ID);
        }

        /// <summary>
        /// verifies setter for RoomPlan.Layout
        /// </summary>
        [Fact]
        public void RoomPlan_CanSetLayout()
        {
            RoomPlan roomplan = new RoomPlan();
            roomplan.Layout = Layout.Studio;
            roomplan.Layout = Layout.OneBedroom;
            Assert.Equal(Layout.OneBedroom, roomplan.Layout);
        }

        /// <summary>
        /// verifies setter for RoomPlan.RoomType
        /// </summary>
        [Fact]
        public void RoomPlan_CanSetRoomType()
        {
            RoomPlan roomplan = new RoomPlan();
            roomplan.RoomType = "teststring";
            roomplan.RoomType = "newstring";
            Assert.Equal("newstring", roomplan.RoomType);
        }

        /// <summary>
        /// verifies setter for RoomPlan.RoomConfigGroup
        /// </summary>
        [Fact]
        public void RoomPlan_CanSetRoomConfigGroup()
        {
            RoomPlan roomPlan = new RoomPlan();
            roomPlan.RoomConfigGroup = new List<RoomConfig>();
            roomPlan.RoomConfigGroup.Add(new RoomConfig());
            roomPlan.RoomConfigGroup.Add(new RoomConfig());
            roomPlan.RoomConfigGroup.Add(new RoomConfig());
            roomPlan.RoomConfigGroup.Add(new RoomConfig());
            Assert.Equal(4, roomPlan.RoomConfigGroup.Count);
        }
    }
}
