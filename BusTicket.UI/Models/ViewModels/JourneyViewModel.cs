using BusTicket.UI.Models.Api.Response.DataModels;
using System.Collections.Generic;

namespace BusTicket.UI.Models.ViewModels
{
    public class JourneyViewModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public List<JourneyViewModelItem> Journeys { get; set; }
    }
}