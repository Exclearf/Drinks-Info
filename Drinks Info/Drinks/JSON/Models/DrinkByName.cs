using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Drinks_Info.Drinks.JSON.Models
{
    public class DrinkByName
    {
        [JsonPropertyName("strDrink")]
        public string Name { get; set; }


        [JsonPropertyName("idDrink")]
        public string ID { get; set; }
    }

    public class DrinksByName
    {
        public List<DrinkByName> drinks { get; set; }
    }
}
