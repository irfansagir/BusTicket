using Newtonsoft.Json;
using System;

namespace BusTicket.UI.Models.Api.Response.DataModels
{
    public class JourneyModel
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string Currency { get; set; }
        [JsonProperty("internet-price")]
        public decimal InternetPrice { get; set; }
    }
}