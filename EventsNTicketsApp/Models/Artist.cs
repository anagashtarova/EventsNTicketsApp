using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsNTicketsApp.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string VideoId { get; set; }
        public string Bio { get; set; } 
        public virtual ICollection<Event> Events { get; set; }

        public Artist()
        {
            Events = new List<Event>();
        }

    }
}