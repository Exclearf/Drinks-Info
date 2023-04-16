using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_Info.Drinks.JSON
{
    public class ShowJSON<T> where T : class
    {
        public static void Show(string? title, List<T> obj, bool ShowMetaData) 
        {
            Console.Clear();
            var m =
                ConsoleTableBuilder.From(obj)
                .WithTitle(title)
                .WithTextAlignment(new Dictionary<int, TextAligntment>
                {
                    {0, TextAligntment.Center }
                })
                //.WithColumn(new List<string> { null })
                .WithCharMapDefinition(CharMapDefinition.FramePipDefinition);
                //.Export().ToString().Split("\n│");
                if (!ShowMetaData)
                m = m.WithColumn(new List<string> { null });
                var menu = m.Export().ToString().Split("\n│");
            for (int i = 0; i < menu.Length; i++)
            {
                if (menu[i].IndexOf("├") > 0 && i > 0 && i < menu.Length - 1)
                {
                    var eachLine = menu[i].Split("├");
                    Console.Write(eachLine[0]);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("├");
                    Console.ResetColor();
                    Console.Write(eachLine[1]);
                }
                else
                    Console.Write(menu[i]);
                if (i < menu.Length - 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\n│");
                    Console.ResetColor();
                }
            }
        }
    }
}
