using BusTicket.UI.Models.Api;
using BusTicket.UI.Models.Api.Request.DataModels;
using BusTicket.UI.Models.Api.Response;
using System.Threading.Tasks;

namespace BusTicket.UI.Services.Interfaces
{
    public interface ITicketService
    {
        Task<SessionResponseModel> GetSession();
        Task<BusLocationResponseModel> GetBusLocations(SessionDeviceDataModel sessionDeviceModel);
        Task<JourneyResponseModel> GetJourneys(SessionDeviceDataModel sessionDeviceModel, JourneyRequestDataModel journeyModel);
    }
}