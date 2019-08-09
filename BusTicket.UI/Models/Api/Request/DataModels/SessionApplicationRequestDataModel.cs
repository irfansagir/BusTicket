using Newtonsoft.Json;

namespace BusTicket.UI.Models.Api.Request.DataModels
{
    public class SessionApplicationRequestDataModel
    {
        [JsonProperty("equipment-id")]
        public string EquipmentId { get; set; }
        public string Version { get; set; }
    }
}