using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomPlan
    {
        public int ID { get; set; }
        public Layout Layout { get; set; }
        public string RoomType { get; set; }

        public ICollection<RoomConfig> RoomConfigGroup { get; set; }

    }

    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom
    }
}
