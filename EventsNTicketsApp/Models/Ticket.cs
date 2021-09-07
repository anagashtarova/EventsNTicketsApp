using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsNTicketsApp.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string Type { get; set; }
        public string Block { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<TicketSeat> TicketSeats { get; set; }
    }
}