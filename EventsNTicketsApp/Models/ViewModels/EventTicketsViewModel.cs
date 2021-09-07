using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsNTicketsApp.Models.ViewModels
{
    public class EventTicketsViewModel
    {
        public Event Event { get; set; }
        public List<Ticket> Tickets { get; set; }
        public EventTicketsViewModel()
        {
            Event = new Event();
            Tickets = new List<Ticket>();
        }
        public EventTicketsViewModel(Event e,List<Ticket> t)
        {
            Event = e;
            Tickets = t;
        }
    }
}