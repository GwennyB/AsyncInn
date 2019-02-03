using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Inventory
    {
        //public int ID { get; set; }
        public int RoomNumber { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Rate { get; set; }
        public bool PetsOK { get; set; }
        [DisplayName("Room Name")]
        public string RoomName { get; set; }
        
        // Foreign Keys
        public int HotelID { get; set; }
        public int RoomPlanID { get; set; }


        // Navigation Properties
        public Hotel Hotel { get; set; }
        public RoomPlan RoomPlan { get; set; }
    }

}
