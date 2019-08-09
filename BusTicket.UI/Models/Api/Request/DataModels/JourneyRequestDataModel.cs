using Newtonsoft.Json;
using System;

namespace BusTicket.UI.Models.Api.Request.DataModels
{
    public class JourneyRequestDataModel
    {
        [JsonProperty("origin-id")]
        public int OriginId { get; set; }
        [JsonProperty("destination-id")]
        public int DestinationId { get; set; }
        [JsonProperty("departure-date")]
        public DateTime DepartureDate { get; set; }
    }
}