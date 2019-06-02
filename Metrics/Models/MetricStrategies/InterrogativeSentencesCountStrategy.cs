using Metrics.Models.MetricStrategies;
using System.Linq;
using System.Text.RegularExpressions;

namespace Metrics.Models
{
    public class InterrogativeSentencesCountStrategy : MetricStrategy
    {
        public override string Predicate { get => "Количество вопросительных предложений: "; }

        public InterrogativeSentencesCountStrategy(string text)
        {
            Text = Regex.Replace(text, @"[?]+", "?");
        }

        private void CountInterrogativeSentences()
        {
            Result = Predicate + Text.Where(ch => ch == '?').ToList().Count;
        }

        public override void Process()
        {
            CountInterrogativeSentences();
        }
    }
}