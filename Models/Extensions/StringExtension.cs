using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InfotechVision.Models.Extensions
{
    public static class StringExtension
    {
        public static string ToTitleCase(this String input)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            string finalString = textInfo.ToTitleCase(input.ToLower());
            return finalString;
        }
    }
}
