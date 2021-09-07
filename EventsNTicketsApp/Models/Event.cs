using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsNTicketsApp.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public float Price { get; set; }
        public int Capacity { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}