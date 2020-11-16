using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPlanner.Data
{
    public class Card
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public bool SentCard { get; set; }
        [ForeignKey(nameof(PersonID))]
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
    }
}
