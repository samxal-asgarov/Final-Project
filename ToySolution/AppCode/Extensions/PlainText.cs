using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToySolution.AppCode.Extensions
{
   static public partial  class PlainText
   {

        static public string PlainTexts(this string text)
        {
            return Regex.Replace(text, @"<[^>]*>", "");
        }

    }
}
