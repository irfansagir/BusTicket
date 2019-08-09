using BusTicket.UI.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace BusTicket.UI.Handlers.Journey.Queries
{
    public class GetJourneyQuery : IRequest<List<JourneyViewModelItem>>
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}