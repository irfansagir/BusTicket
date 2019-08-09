using BusTicket.UI.Handlers.BusLocation.Queries;
using BusTicket.UI.Handlers.Journey.Queries;
using BusTicket.UI.Models;
using BusTicket.UI.Models.ViewModels;
using BusTicket.UI.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BusTicket.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICookieService _cookieService;

        public HomeController(IMediator mediator, ICookieService cookieService)
        {
            _mediator = mediator;
            _cookieService = cookieService;
        }

        public async Task<IActionResult> Index()
        {
            var model = _cookieService.Get<SearchViewModel>("search-model") ?? new SearchViewModel();
            model.Date = DateTime.Now.Date.AddDays(1);

            if (model.FromId <= 0 || model.ToId <= 0)
            {
                var result = await _mediator.Send(new GetBusLocationQuery());

                model.FromId = result[0].Data;
                model.FromText = result[0].Value;
                model.ToId = result[1].Data;
                model.ToText = result[1].Value;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(SearchViewModel model)
        {
            if (model.FromId == model.ToId)
            {
                ModelState.AddModelError("FromText", "Başlangıç ve varış noktası aynı olamaz!");
                return View(model);
            }

            if (model.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("Date", "Bugün ve daha sonraki bir tarih için arama yapabilirsiniz!");
                return View(model);
            }

            _cookieService.Set("search-model", model, 1);
            return RedirectToAction("Journey");
        }

        public async Task<IActionResult> Journey()
        {
            var searchModel = _cookieService.Get<SearchViewModel>("search-model");

            if (searchModel == null)
            {
                return RedirectToAction("Index");
            }

            var model = new JourneyViewModel
            {
                Title = $"{searchModel.FromText} - {searchModel.ToText}",
                SubTitle = searchModel.Date.ToString("dd MMMM dddd"),
                Journeys = await _mediator.Send(new GetJourneyQuery
                {
                    OriginId = searchModel.FromId,
                    DestinationId = searchModel.ToId,
                    DepartureDate = searchModel.Date
                })
            };

            return View(model);
        }

        public async Task<IActionResult> Locations()
        {
            var result = await _mediator.Send(new GetBusLocationQuery());

            return Ok(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}