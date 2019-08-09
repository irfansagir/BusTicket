using BusTicket.UI.Models.Api.Request.DataModels;

namespace BusTicket.UI.Models.Api.Request
{
    public class SessionRequestModel
    {
        public int Type { get; set; }
        public SessionConnectionRequestDataModel Connection { get; set; }
        public SessionApplicationRequestDataModel Application { get; set; }
    }
}