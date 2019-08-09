using BusTicket.UI.Handlers.Session.Queries.GetSession;
using BusTicket.UI.Models.Api;
using BusTicket.UI.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BusTicket.UI.Services
{
    public class SessionService : ISessionService
    {
        private readonly string _deviceDataSessionKey = "DeviceSessionData";
        private readonly ISession _session;
        private readonly IMediator _mediator;

        public SessionService(IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _mediator = mediator;
        }

        public async Task<SessionDeviceDataModel> GetSessionDeviceData()
        {
            SessionDeviceDataModel model = default;
            var sessionValue = _session.GetString(_deviceDataSessionKey);
            if (string.IsNullOrWhiteSpace(sessionValue))
            {
                model = (await _mediator.Send(new GetSessionQuery()))?.Data;
            }
            else
            {
                model = JsonConvert.DeserializeObject<SessionDeviceDataModel>(sessionValue);
            }

            return model;
        }

        public void SetSessionDeviceData(SessionDeviceDataModel model)
            => _session.SetString(_deviceDataSessionKey, JsonConvert.SerializeObject(model));
    }
}
