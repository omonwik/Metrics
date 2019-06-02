using Metrics.Models.MetricStrategies;
using System.Linq;

namespace Metrics.Models
{
    public class LettersCountStrategy : MetricStrategy
    {
        public override string Predicate { get => "Количество букв в тексте: "; protected set { Predicate = value; } }


        public LettersCountStrategy(string text)
        {
            Text = text;
        }

        public override void Process()
        {
            CalculateLetters();
        }

        private void CalculateLetters()
        {
            Result = Predicate + Text.Where(ch => char.IsLetter(ch)).ToArray().Length;
        }
    }
}