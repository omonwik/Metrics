using Metrics.Models.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Metrics.Models
{
    public class LettersCountStrategy : IMetricsStrategy
    {
        public string Text { get; }

        public string Result { get; private set; }

        public LettersCountStrategy(string text)
        {
            Text = text;
        }

        public void Process()
        {
            Result = "Количество букв в тексте: " + Text.Where(ch => char.IsLetter(ch)).ToArray().Length.ToString();
        }

        public async Task ProcessAsync()
        {
            await Task.Run(Process);
        }
    }
}