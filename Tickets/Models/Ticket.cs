using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets.Models
{
    public class Ticket
    {
        [Key]
        public long Id { get; set; }
        [Required]        
        public String Description { get; set; }
        public String AuthorName { get; set; }
        public DateTime Date { get; set; }
    }
}
