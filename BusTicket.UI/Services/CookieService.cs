using BusTicket.UI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.UI.Services
{
    public class CookieService : ICookieService
    {
        private readonly IResponseCookies _responseCookie;
        private readonly IRequestCookieCollection _requestCookie;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _responseCookie = httpContextAccessor.HttpContext.Response.Cookies;
            _requestCookie = httpContextAccessor.HttpContext.Request.Cookies;
        }

        public T Get<T>(string key)
        {
            var value = _requestCookie[key];
            return string.IsNullOrWhiteSpace(value) ? default : JsonConvert.DeserializeObject<T>(value);
        }

        public void Set(string key, object value, int days)
        {
            var cookieValue = JsonConvert.SerializeObject(value);
            _responseCookie.Append(
                key,
                cookieValue,
                new CookieOptions { Expires = DateTime.Now.AddYears(days), IsEssential = true });
        }
    }
}
