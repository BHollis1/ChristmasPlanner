using ChristmasPlanner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPlanner.Models
{
    public class GiftListItem
    {
        
        public int GiftID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Bought Gift")]
       
        public bool BoughtGift { get; set; }
        [Display(Name = "Name:")]
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }

    }
}
