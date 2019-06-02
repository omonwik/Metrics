using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Metrics.Models.Interfaces;

namespace Metrics.Models
{
    public class ExclamatorySentencesCount : IMetricsStrategy
    {
        public string Text { get; }

        public string Result { get; private set; }

        public ExclamatorySentencesCount(string text)
        {
            Text = Regex.Replace(text, @"[!]+", "!");
        }

        public string Process()
        {
            CountExclamatorySentences();
            return Result;
        }

        private void CountExclamatorySentences()
        {
            Result = "Количество восклицательных предложений: " + Text.Where(ch => ch == '!').ToList().Count.ToString();
        }

        public async Task ProcessAsync()
        {
            await Task.Run(Process);
        }
    }
}