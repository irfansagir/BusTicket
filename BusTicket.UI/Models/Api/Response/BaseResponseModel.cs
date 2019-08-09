using Newtonsoft.Json;

namespace BusTicket.UI.Models.Api.Response
{
    public class BaseResponseModel<T>
    {
        public string Status { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        [JsonProperty("user-message")]
        public string UserMessage { get; set; }
        [JsonProperty("api-request-id")]
        public string ApiRequestId { get; set; }
        public string Controller { get; set; }
    }
}