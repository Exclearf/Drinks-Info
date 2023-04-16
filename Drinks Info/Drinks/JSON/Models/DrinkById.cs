using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Drinks_Info.Drinks.JSON.Models
{
    public class DrinkById
    {
        [JsonPropertyName("strDrink")]
        public string Drink { get; set; }
        [JsonPropertyName("strAlcoholic")]
        public string Alcoholic { get; set; }
        [JsonPropertyName("strGlass")]
        public string Glass { get; set; }
        [JsonPropertyName("strInstructions")]
        public string Instructions { get; set; }
        [JsonPropertyName("strIngredient1")]
        public string strIngredient1 { get; set; }
        [JsonPropertyName("strIngredient2")]
        public string strIngredient2 { get; set; }
        [JsonPropertyName("strIngredient3")]
        public string strIngredient3 { get; set; }
        [JsonPropertyName("strIngredient4")]
        public string strIngredient4 { get; set; }
        [JsonPropertyName("strIngredient5")]
        public object strIngredient5 { get; set; }
        [JsonPropertyName("strIngredient6")]
        public object strIngredient6 { get; set; }
        [JsonPropertyName("strIngredient7")]
        public object strIngredient7 { get; set; }
        [JsonPropertyName("strIngredient8")]
        public object strIngredient8 { get; set; }
        [JsonPropertyName("strIngredient9")]
        public object strIngredient9 { get; set; }
        [JsonPropertyName("strIngredient10")]
        public object strIngredient10 { get; set; }
        [JsonPropertyName("strIngredient11")]
        public object strIngredient11 { get; set; }
        [JsonPropertyName("strIngredient12")]
        public object strIngredient12 { get; set; }
        [JsonPropertyName("strIngredient13")]
        public object strIngredient13 { get; set; }
        [JsonPropertyName("strIngredient14")]
        public object strIngredient14 { get; set; }
        [JsonPropertyName("strIngredient15")]
        public object strIngredient15 { get; set; }
        [JsonPropertyName("strMeasure1")]
        public string strMeasure1 { get; set; }
        [JsonPropertyName("strMeasure2")]
        public string strMeasure2 { get; set; }
        [JsonPropertyName("strMeasure3")]
        public string strMeasure3 { get; set; }
        [JsonPropertyName("strMeasure4")]
        public object strMeasure4 { get; set; }
        [JsonPropertyName("strMeasure5")]
        public object strMeasure5 { get; set; }
        [JsonPropertyName("strMeasure6")]
        public object strMeasure6 { get; set; }
        [JsonPropertyName("strMeasure7")]
        public object strMeasure7 { get; set; }
        [JsonPropertyName("strMeasure8")]
        public object strMeasure8 { get; set; }
        [JsonPropertyName("strMeasure9")]
        public object strMeasure9 { get; set; }
        [JsonPropertyName("strMeasure10")]
        public object strMeasure10 { get; set; }
        [JsonPropertyName("strMeasure11")]
        public object strMeasure11 { get; set; }
        [JsonPropertyName("strMeasure12")]
        public object strMeasure12 { get; set; }
        [JsonPropertyName("strMeasure13")]
        public object strMeasure13 { get; set; }
        [JsonPropertyName("strMeasure14")]
        public object strMeasure14 { get; set; }
        [JsonPropertyName("strMeasure15")]
        public object strMeasure15 { get; set; }
        [JsonPropertyName("strDrinkThumb")]
        public string Image { get; set; }
    }

    public class DrinksById
    {
        public List<DrinkById> drinks { get; set; }
    }

}
