using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Helpers;
using WebApplication3.Models.Interfaces;

namespace WebApplication3.Models
{
    public class MostUsedSymbolStrategy : IMetricsStrategy
    {
        public string Text { get; }
        public string Result { get; private set; }

        public MostUsedSymbolStrategy(string text)
        {
            Text = text.ToLowerInvariant().Replace(" ", string.Empty);
        }

        public string Process()
        {
            SearchMostUsedSymbol();
            return Result;
        }

        public async Task ProcessAsync()
        {
            await Task.Run(Process);
        }

        private void SearchMostUsedSymbol()
        {
            if (string.IsNullOrEmpty(Text)) return;

            var chars = new Dictionary<char, int>();
            for (int i = 0, y = Text.Length - 1; y >= i; i++, y--)
            {
                chars.AddOrUpdate(Text[i]);

                if (i == y) break;

                chars.AddOrUpdate(Text[y]);
            }

            var result = chars.Where(k => k.Value == chars.Values.Max()).Select(k => k.Key).ToList();

            Result = "Самый(е) используемый(ые) символ(ы): " + string.Join(", ", result);
        }
    }
}