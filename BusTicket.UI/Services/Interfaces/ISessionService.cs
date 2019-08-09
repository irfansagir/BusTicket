using BusTicket.UI.Models.Api;
using System.Threading.Tasks;

namespace BusTicket.UI.Services.Interfaces
{
    public interface ISessionService
    {
        Task<SessionDeviceDataModel> GetSessionDeviceData();
        void SetSessionDeviceData(SessionDeviceDataModel model);
    }
}