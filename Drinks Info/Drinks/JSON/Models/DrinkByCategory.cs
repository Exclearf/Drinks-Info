using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Drinks_Info.Drinks.JSON.Models
{
    public class DrinkByCategory
    {
        [JsonPropertyName("strCategory")]
        public string Categories { get; set; }
    }

    public class DrinksByCategory
    {
        [JsonPropertyName("drinks")]
        public List<DrinkByCategory> Drinks { get; set; }
    }
}
