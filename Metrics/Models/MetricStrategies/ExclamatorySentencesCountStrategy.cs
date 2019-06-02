using Metrics.Models.MetricStrategies;
using System.Linq;
using System.Text.RegularExpressions;

namespace Metrics.Models
{
    public class ExclamatorySentencesCountStrategy : MetricStrategy
    {
        public override string Predicate { get => "Количество восклицательных предложений: "; protected set { Predicate = value; } }

        public ExclamatorySentencesCountStrategy(string text)
        {
            Text = Regex.Replace(text, @"[!]+", "!");
        }

        public override void Process()
        {
            CountExclamatorySentences();
        }

        private void CountExclamatorySentences()
        {
            Result = Predicate + Text.Where(ch => ch == '!').ToList().Count;
        }
    }
}