using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomPlan
    {
        public int ID { get; set; }
        public Layout Layout { get; set; }

        [DisplayName("Room Plan Name")]
        public string RoomType { get; set; }

        [DisplayName("Amenities")]
        public ICollection<RoomConfig> RoomConfigGroup { get; set; }

    }

    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom
    }
}
