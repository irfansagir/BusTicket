using BusTicket.UI.Models.Api.Response;
using BusTicket.UI.Models.ViewModels;
using BusTicket.UI.Services.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusTicket.UI.Handlers.BusLocation.Queries
{
    public class GetBusLocationQueryHandler : IRequestHandler<GetBusLocationQuery, List<AutoCompleteViewModel>>
    {
        private readonly ISessionService _sessionService;
        private readonly ITicketService _ticketService;

        public GetBusLocationQueryHandler(ITicketService ticketService, ISessionService sessionService)
        {
            _sessionService = sessionService;
            _ticketService = ticketService;
        }

        public async Task<List<AutoCompleteViewModel>> Handle(GetBusLocationQuery request, CancellationToken cancellationToken)
        {
            var sessionDeviceData = await _sessionService.GetSessionDeviceData();
            var result = (await _ticketService.GetBusLocations(sessionDeviceData))?.Data
                .Select(p => new AutoCompleteViewModel
                {
                    Data = p.Id,
                    Value = p.Name
                }).ToList();

            return result;
        }
    }
}