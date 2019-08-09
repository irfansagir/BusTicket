using BusTicket.UI.Models.Api.Request.DataModels;
using BusTicket.UI.Models.ViewModels;
using BusTicket.UI.Services.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusTicket.UI.Handlers.Journey.Queries
{
    public class GetJourneyQueryHandler : IRequestHandler<GetJourneyQuery, List<JourneyViewModelItem>>
    {
        private readonly ISessionService _sessionService;
        private readonly ITicketService _ticketService;

        public GetJourneyQueryHandler(ITicketService ticketService, ISessionService sessionService)
        {
            _sessionService = sessionService;
            _ticketService = ticketService;
        }

        public async Task<List<JourneyViewModelItem>> Handle(GetJourneyQuery request, CancellationToken cancellationToken)
        {
            var deviceSessionData = await _sessionService.GetSessionDeviceData();

            var result = await _ticketService.GetJourneys(deviceSessionData, new JourneyRequestDataModel
            {
                DepartureDate = request.DepartureDate,
                DestinationId = request.DestinationId,
                OriginId = request.OriginId
            });

            return result?.Data.Select(p => new JourneyViewModelItem
            {
                ArrivalTime = p.Journey.Arrival.ToString("HH:mm"),
                DepartureTime = p.Journey.Departure.ToString("HH:mm"),
                Location = $"{p.Journey.Origin} - {p.Journey.Destination}",
                Price = $"{p.Journey.InternetPrice} - {p.Journey.Currency}"
            }).ToList();
        }
    }
}
