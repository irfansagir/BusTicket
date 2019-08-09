using Newtonsoft.Json;

namespace BusTicket.UI.Models.Api.Response.DataModels
{
    public class JourneyResponseDataModel
    {
        public int Id { get; set; }
        [JsonProperty("partner-id")]
        public int PartnerId { get; set; }
        [JsonProperty("partner-name")]
        public string PartnerName { get; set; }
        public JourneyModel Journey { get; set; }
    }
}