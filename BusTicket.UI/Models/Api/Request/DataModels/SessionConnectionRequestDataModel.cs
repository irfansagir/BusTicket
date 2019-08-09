using Newtonsoft.Json;

namespace BusTicket.UI.Models.Api.Request.DataModels
{
    public class SessionConnectionRequestDataModel
    {
        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }
    }
}