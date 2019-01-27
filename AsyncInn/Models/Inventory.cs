using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Inventory
    {
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public bool PetsOK { get; set; }
        
        // Foreign Keys
        public int HotelID { get; set; }
        public int RoomPlanID { get; set; }

        public ICollection<RoomPlan> RoomPlans { get; set; }

        // Navigation Properties
        public Hotel Hotel { get; set; }
        public RoomPlan RoomPlan { get; set; }
    }
}
