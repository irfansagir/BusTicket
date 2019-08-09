using System;

namespace BusTicket.UI.Models.ViewModels
{
    public class SearchViewModel
    {
        public int FromId { get; set; }
        public string FromText { get; set; }
        public int ToId { get; set; }
        public string ToText { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.Date;
    }
}
