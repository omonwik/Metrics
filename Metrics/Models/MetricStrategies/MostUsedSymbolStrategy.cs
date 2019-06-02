using Metrics.Helpers;
using Metrics.Models.MetricStrategies;
using System.Collections.Generic;
using System.Linq;

namespace Metrics.Models
{
    public class MostUsedSymbolStrategy : MetricStrategy
    {
        public override string Predicate { get => "Самый(е) используемый(е) символ(ы): ";}

        public MostUsedSymbolStrategy(string text)
        {
            Text = text.ToLowerInvariant().Replace(" ", string.Empty);
        }

        public override void Process()
        {
            SearchMostUsedSymbol();
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

            Result = Predicate + string.Join(", ", result);
        }
    }
}