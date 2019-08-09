using BusTicket.UI.Models.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.UI.Handlers.Session.Queries.GetSession
{
    public class GetSessionQuery : IRequest<SessionResponseModel>
    {
    }
}