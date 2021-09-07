using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsNTicketsApp.Models.ViewModels
{
    public class TicketToTicketSeatsViewModel
    {
        public Ticket Ticket { get; set; }
        public List<TicketSeat> TicketSeats { get; set; }
        public TicketToTicketSeatsViewModel()
        {
            Ticket = new Ticket();
            TicketSeats = new List<TicketSeat>();
        }
        public TicketToTicketSeatsViewModel(Ticket t, List<TicketSeat> s)
        {
            TicketSeats = s;
            Ticket = t;
        }
    }
}