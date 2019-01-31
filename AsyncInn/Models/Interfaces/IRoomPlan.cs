using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomPlan
    {
        // create
        Task CreateRoomPlan(RoomPlan roomPlan);

        // read
        List<RoomPlan> GetRoomPlans();

        // update
        Task UpdateRoomPlan(RoomPlan roomPlan);

        // delete
        Task DeleteRoomPlan(RoomPlan roomPlan);
    }
}
