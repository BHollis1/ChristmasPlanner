﻿using ChristmasPlanner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPlanner.Models
{
    public class CardCreate
    {
        public bool SentCard { get; set; }
        [Display(Name = "Name")]
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
    }
}
