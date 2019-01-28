using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomConfig
    {
        public int RoomPlanID { get; set; }
        public int AmenityID { get; set; }

        // Navigation Properties
        public RoomPlan RoomPlan { get; set; }
        public Amenity Amenity { get; set; }
    }

}
