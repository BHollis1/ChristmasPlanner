using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPlanner.Models
{
    public class GiftDetail
    {
        public int GiftID { get; set; }
        public string Description { get; set; }
        
        [Display(Name = "Bought Gift")]
        public bool BoughtGift { get; set; }
        public int PersonID { get; set; }
    }
}
