using BusTicket.UI.Models.Api;
using BusTicket.UI.Models.Api.Request;
using BusTicket.UI.Models.Api.Request.DataModels;
using BusTicket.UI.Models.Api.Response;
using BusTicket.UI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace BusTicket.UI.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRestClient _restClient;
        private readonly IExternalIpAddressService _externalIpAddressService;

        public TicketService(IRestClient restClient, IExternalIpAddressService externalIpAddressService, IHttpContextAccessor httpContextAccessor)
        {
            var browser = httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
            _restClient = restClient;
            _externalIpAddressService = externalIpAddressService;
        }

        public async Task<BusLocationResponseModel> GetBusLocations(SessionDeviceDataModel sessionDeviceModel)
            => await Execute<BusLocationRequestModel, BusLocationResponseModel>("location/getbuslocations", new BusLocationRequestModel
            {
                Data = null,
                Language = "tr-TR",
                DeviceSession = sessionDeviceModel,
                Date = DateTime.UtcNow,
            });

        public async Task<JourneyResponseModel> GetJourneys(SessionDeviceDataModel sessionDeviceModel, JourneyRequestDataModel journeyModel)
            => await Execute<JourneyRequestModel, JourneyResponseModel>("journey/getbusjourneys", new JourneyRequestModel
            {
                Data = journeyModel,
                DeviceSession = sessionDeviceModel,
                Date = DateTime.UtcNow,
                Language = "tr-TR"
            });

        public async Task<SessionResponseModel> GetSession()
            => await Execute<SessionRequestModel, SessionResponseModel>("client/getsession", new SessionRequestModel
            {
                Type = 7,
                Connection = new SessionConnectionRequestDataModel
                {
                    IpAddress = await _externalIpAddressService.Get()
                },
                Application = new SessionApplicationRequestDataModel
                {
                    EquipmentId = "distribusion",
                    Version = "1.0.0.0"
                }
            });

        private async Task<TResponse> Execute<TRequest, TResponse>(string api, TRequest body)
            where TRequest : new()
            where TResponse : new()
        {
            var request = new RestRequest(api);
            request.AddJsonBody(JsonConvert.SerializeObject(body));
            var response = await _restClient.PostAsync<TResponse>(request);
            return response;
        }


    }
}
