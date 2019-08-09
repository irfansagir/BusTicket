using BusTicket.UI.Models.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace BusTicket.UI.Handlers.BusLocation.Queries
{
    public class GetBusLocationQuery : IRequest<List<AutoCompleteViewModel>>
    {
    }
}