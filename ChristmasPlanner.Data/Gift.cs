using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPlanner.Data
{
    public class Gift
    {
        [Key]
        public int GiftID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool BoughtGift { get; set; }
        public int PersonID { get; set; }
        [ForeignKey(nameof(PersonID))]
        public virtual Person Person { get; set; }
        

    }
}
