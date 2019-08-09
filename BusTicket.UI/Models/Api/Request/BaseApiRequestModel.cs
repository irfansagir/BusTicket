using Newtonsoft.Json;
using System;

namespace BusTicket.UI.Models.Api.Request
{
    public class BaseApiRequestModel<T> where T : new()
    {
        public T Data { get; set; } = new T();

        [JsonProperty("device-session")]
        public SessionDeviceDataModel DeviceSession { get; set; }
        public DateTime Date { get; set; }
        public string Language { get; set; }
    }
}