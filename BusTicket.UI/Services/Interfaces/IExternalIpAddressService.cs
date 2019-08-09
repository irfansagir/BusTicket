using System.Threading.Tasks;

namespace BusTicket.UI.Services.Interfaces
{
    public interface IExternalIpAddressService
    {
        Task<string> Get();
    }
}