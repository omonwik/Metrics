using Metrics.Models.MetricStrategies;
using System.Text.RegularExpressions;

namespace Metrics.Models
{
    public class WordsCountStrategy : MetricStrategy
    {
        public WordsCountStrategy(string text)
        {
            Text = Regex.Replace(text, @"\s+", " ");
        }

        public override string Predicate { get => "Количество слов в тексте: "; protected set { Predicate = value; } }

        public override void Process()
        {
            CalculateWordsCount();
        }

        private void CalculateWordsCount()
        {
            Result = Predicate + Text.Split(new char[] { ' ' }).Length;
        }
    }
}