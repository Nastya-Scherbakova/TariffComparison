using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TariffComparison.Models
{
    class Product
    {
        [JsonProperty("name")]
        public string Name { get; set;}
        [JsonProperty("baseCostPerYear")]
        public decimal BaseCostPerYear { get; set;}
        [JsonProperty("limits")]
        public List<Limit> Limits { get; set;}
    }

}
