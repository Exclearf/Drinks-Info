using ConsoleTableExt;
using Drinks_Info.Drinks;
using Drinks_Info.Drinks.Convert;
using Drinks_Info.Drinks.JSON;
using Drinks_Info.Drinks.JSON.Models;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;


namespace Drinks_Info
{
    public class DrinksMain
    {
        public static async Task Main()
        {
            //OpenURL("https://google.com");
            string? categoryChoice = await ShowCategoriesAndGetChoice();
            string? cocktailChoice = await ShowChosenAndGetChoice(categoryChoice);

            //11007
            Console.Clear();
            var json = await JSON<DrinksById>.GetJSON("https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=" + CustomConvert.ToTitleCase(cocktailChoice));
            //ShowJSON<DrinkById>.Show("Drinks", json.drinks, true);
            Console.ResetColor();
            if(json.drinks.First() != null)
            {
                var currentDrink = json.drinks.First();
                int i = 1;
                foreach (var prop in currentDrink.GetType().GetProperties())
                {
                    if (prop.GetValue(currentDrink, null) != null)
                    {
                        switch (prop.Name)
                        {
                            case "strIngredient1":
                                await Console.Out.WriteLineAsync($"Ingredients: \n{i++}. " + prop.GetValue(currentDrink, null).ToString());
                                break;
                            case "strMeasure1":
                                await Console.Out.WriteLineAsync($"Measures: \n- " + prop.GetValue(currentDrink, null).ToString());
                                break;
                            case "Alcoholic":
                                await Console.Out.WriteLineAsync(prop.GetValue(currentDrink, null).ToString());
                                break;
                            case "Image":
                                continue;
                                break;
                            default:
                                if (prop.Name.Contains("Ingredient"))
                                    Console.Out.WriteLineAsync($"{i++}. " + prop.GetValue(currentDrink, null));
                                else if (prop.Name.Contains("Measure"))
                                    await Console.Out.WriteLineAsync($"- " + prop.GetValue(currentDrink, null));
                                else
                                    await Console.Out.WriteLineAsync(prop.Name + ": " + prop.GetValue(currentDrink, null).ToString());
                                break;
                        }
                    }
                }
                await Console.Out.WriteLineAsync("\n\nPress 0 to exit\n" +
                        "Press 1 to view the image of the drink\nPress any other key to continue...");
                var choice = Console.ReadLine();
                if (choice == "0")
                {
                    await Console.Out.WriteLineAsync("Was nice having you here!");
                    Environment.Exit(0);
                }
                else if (choice == "1")
                {
                    var c = currentDrink.GetType().GetProperties().ElementAt(currentDrink.GetType().GetProperties().ToList().FindIndex(x => x.Name == "Image"));
                    
                    if(c.GetValue(currentDrink, null) != null)
                        OpenURL(c.GetValue(currentDrink, null).ToString());
                    else
                        Console.WriteLine("Sorry, unable to find an image!");
                    //OpenURL(currentDrink.GetType().GetProperties().ToList().Find(x => x.Name == "Image").GetValue(currentDrink, null).ToString());
                }
                await Console.Out.WriteLineAsync("\n\nPress any other key to continue...");
                Console.ReadKey();
                await DrinksMain.Main();
            }
        }

        public static void OpenURL(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private static async Task<string?> ShowChosenAndGetChoice(string choice)
        {
            var json = await JSON<DrinksByName>.GetJSON("https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=" + CustomConvert.ToTitleCase(choice));
            ShowJSON<DrinkByName>.Show("Drinks", json.drinks, true);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            await Console.Out.WriteAsync("Input: ");
            Console.ResetColor();
            var input = await Console.In.ReadLineAsync();
            return input;
        }

        private static async Task<string?> ShowCategoriesAndGetChoice()
        {
            var json = await JSON<DrinksByCategory>.GetJSON(ConfigurationManager.AppSettings["Categories"]);
            ShowJSON<DrinkByCategory>.Show("Categories", json.Drinks, false);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            await Console.Out.WriteAsync("Input ID: ");
            Console.ResetColor();
            var choice = await Console.In.ReadLineAsync();
            return choice;
        }
    }
}