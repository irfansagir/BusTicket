using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.UI.Models.Api.Response.DataModels
{
    public class BusLocationResponseDataModel
    {
        public int Id { get; set; }
        [JsonProperty("parent-id")]
        public int ParentId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int? Rank { get; set; }
    }
}