using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_Info.Drinks.Convert
{
    public class CustomConvert
    {
        public static string ToTitleCase(string s) { 
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
        }
    }
}
