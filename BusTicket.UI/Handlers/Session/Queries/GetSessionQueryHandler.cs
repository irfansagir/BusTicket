using BusTicket.UI.Models.Api.Response;
using BusTicket.UI.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusTicket.UI.Handlers.Session.Queries.GetSession
{
    public class GetSessionQueryHandler : IRequestHandler<GetSessionQuery, SessionResponseModel>
    {
        private readonly ISessionService _sessionService;
        private readonly ITicketService _ticketService;

        public GetSessionQueryHandler(ITicketService ticketService, ISessionService sessionService)
        {
            _sessionService = sessionService;
            _ticketService = ticketService;
        }

        public async Task<SessionResponseModel> Handle(GetSessionQuery request, CancellationToken cancellationToken)
        {
            var result = await _ticketService.GetSession();
            _sessionService.SetSessionDeviceData(result.Data);
            return result;
        }
    }
}
