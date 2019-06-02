using Metrics.Models.MetricStrategies;

namespace Metrics.Models
{
    public class SymbolsCountStrategy : MetricStrategy
    {
        public override string Predicate { get => "Количество символов в тексте: "; protected set { Predicate = value; } }

        public SymbolsCountStrategy(string text)
        {
            Text = text;
        }

        public override void Process()
        {
            CalculateSymbolsCount();
        }

        private void CalculateSymbolsCount()
        {
            Result = Predicate + Text.Length;
        }
    }
}