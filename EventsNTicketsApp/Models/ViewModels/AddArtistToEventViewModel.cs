using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsNTicketsApp.Models.ViewModels
{
    public class AddArtistToEventViewModel
    {
        public Event Event { get; set; }
        public List<Artist> Artist { get; set; }
        public int SelectedArtist { get; set; }
        
    }
}