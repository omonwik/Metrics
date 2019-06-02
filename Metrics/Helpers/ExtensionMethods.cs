using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metrics.Helpers
{
    public static class ExtensionMethods
    {
        public static void AddOrUpdate(this Dictionary<char, int> dictionary, char c)
        {
            var existingKey = dictionary.Keys.FirstOrDefault(k => k == c);

            if (existingKey == 0)
            {
                dictionary.Add(c, 1);
            }
            else
            {
                dictionary[existingKey]++;
            }
        }
    }
}