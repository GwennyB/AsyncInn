using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomPlanService : IRoomPlan
    {
        // insert context
        private AsyncInnDbContext _context;

        public RoomPlanService(AsyncInnDbContext context)
        {
            _context = context;
        }


        // create
        public async Task CreateRoomPlan(RoomPlan roomPlan)
        {
            _context.RoomPlan.Add(roomPlan);
            await _context.SaveChangesAsync();
        }

        // read
        public List<RoomPlan> GetRoomPlans()
        {
            return _context.RoomPlan.ToList<RoomPlan>();
        }

        // update
        public async Task UpdateRoomPlan(RoomPlan roomPlan)
        {
            _context.RoomPlan.Update(roomPlan);
            await _context.SaveChangesAsync();
        }

        // delete
        public async Task DeleteRoomPlan(RoomPlan roomPlan)
        {
            _context.RoomPlan.Remove(roomPlan);
            await _context.SaveChangesAsync();
        }
    }
}
