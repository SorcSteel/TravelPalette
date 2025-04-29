﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPalette.BL.Models
{
    public class Address
    {
        public int Id { get; set; }

        [DisplayName("Street Name")]
        public string StreetName { get; set; }
        public string City { get; set; }
        public string ZIP { get; set; }
        public string State { get; set; }
    }
}
