using ConsoleTableExt;
using Drinks_Info.Drinks.Convert;
using Drinks_Info.Drinks.JSON.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Drinks_Info.Drinks.JSON
{
    public class JSON<T>
    {
        public static async Task<T> GetJSON(string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "DrinksCategory Reporter");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await using var stream =
                    await client.GetStreamAsync(url.ToString());
                var t =
                    await JsonSerializer.DeserializeAsync<T>(stream);
                return t;
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync("Wrong input! Try again!");
                    var new_url = Console.ReadKey();
                    await DrinksMain.Main();
                    var json = await JSON<T>.GetJSON("https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=" + CustomConvert.ToTitleCase(new_url.ToString().Trim()));
                    return json;
                }
            }
        }        
    }
}
