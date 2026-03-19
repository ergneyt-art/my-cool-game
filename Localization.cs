using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MyCoolGame
{
    public class LocalizableText
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public Dictionary<string, string> Translations = new Dictionary<string, string>();
    }

    public static class Localizable
    {
        public static Dictionary<string, Dictionary<string, Dictionary<string, string>>> GetTexts(List<LocalizableText> source)
        {
            var result = source
                .GroupBy(x => x.Category)
                .ToDictionary(x => x.Key, x => x.ToDictionary(y => y.Name, y => y.Translations));
            return result;
        }
 
    }
}
