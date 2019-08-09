namespace BusTicket.UI.Services.Interfaces
{
    public interface ICookieService
    {
        T Get<T>(string key);
        void Set(string key, object value, int days);
    }
}