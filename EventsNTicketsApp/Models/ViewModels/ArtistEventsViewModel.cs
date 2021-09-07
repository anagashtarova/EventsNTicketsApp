using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsNTicketsApp.Models.ViewModels
{
    public class ArtistEventsViewModel
    {
        public Artist Artist { get; set; }
        public List<Event> Events { get; set; }

        public ArtistEventsViewModel()
        {
            Artist = new Artist();
            Events = new List<Event>();
        }
        public ArtistEventsViewModel(Artist a,List<Event> e)
        {
            Artist = a;
            Events = e;
        }

    }
}