using BusTicket.UI.Services.Interfaces;
using RestSharp;
using System.Threading.Tasks;

namespace BusTicket.UI.Services
{
    public class ExternalIpAddressService : IExternalIpAddressService
    {
        private readonly RestClient _restClient;

        public ExternalIpAddressService(string url)
            => _restClient = new RestClient(url);


        public async Task<string> Get()
        {
            var result = Task.Run(() =>
            {
                var request = new RestRequest(Method.GET);
                var response = _restClient.Execute(request);
                return response.Content.Replace("\n", "");
            });

            return await result;
        }
    }
}
