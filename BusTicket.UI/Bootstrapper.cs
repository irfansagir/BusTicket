using BusTicket.UI.Services;
using BusTicket.UI.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System;

namespace BusTicket.UI
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddServices(this IServiceCollection services, string apiUrl, string apiToken, string externalIpAddressUrl)
        {
            services.AddHttpContextAccessor();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<IRestClient>(p =>
            {
                var restClient = new RestClient(apiUrl);
                restClient.AddDefaultHeader("Content-Type", "application/json");
                restClient.AddDefaultHeader("Authorization", $"Basic {apiToken}");

                return restClient;
            });

            services.AddSingleton<IExternalIpAddressService>(new ExternalIpAddressService(externalIpAddressUrl));
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ICookieService, CookieService>();

            return services;
        }
    }
}