using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsNTicketsApp.Models
{
    public class TicketSeat
    {
        [Key]
        public int TicketSeatId { get; set; }
        public int TicketId { get; set; }
        public string Row { get; set; }
        public string SeatNumber { get; set; }
        public float Price { get; set; }
         
    }
}