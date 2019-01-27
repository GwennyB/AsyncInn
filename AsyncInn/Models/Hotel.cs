﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public int LocationID { get; set; }

        public ICollection<Inventory> HotelInventory { get; set; }

        //Navigation Properties
        public Location Location { get; set; }
    }
}
