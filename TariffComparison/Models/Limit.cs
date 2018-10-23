using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TariffComparison.Models
{
    class Limit
    {
        [JsonProperty("kWhPerYear")]
        public decimal KWhPerYear { get; set;}
        [JsonProperty("addition")]
        public decimal Addition  { get; set;}
    }
}
