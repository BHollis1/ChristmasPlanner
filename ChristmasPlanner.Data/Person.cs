using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPlanner.Data
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        public virtual ICollection<Gift> Gifts { get; set; } = new List<Gift>();
        public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
