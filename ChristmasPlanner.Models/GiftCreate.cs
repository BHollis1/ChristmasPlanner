﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPlanner.Models
{
    public class GiftCreate
    {
        [MaxLength(200, ErrorMessage = "Too many characters. Please enter less than 200 characters")]
        public string Description { get; set; }
       
        public bool BoughtGift { get; set; }
        public int PersonID { get; set; }

    }
}
