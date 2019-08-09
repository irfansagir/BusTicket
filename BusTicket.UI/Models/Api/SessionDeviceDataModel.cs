using Newtonsoft.Json;

namespace BusTicket.UI.Models.Api
{
    public class SessionDeviceDataModel
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }
        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
}