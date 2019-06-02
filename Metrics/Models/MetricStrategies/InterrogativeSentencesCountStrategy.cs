using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Metrics.Models.Interfaces;

namespace Metrics.Models
{
    public class InterrogativeSentencesCount : IMetricsStrategy
    {
        public string Text { get; }

        public string Result { get; private set; }

        public InterrogativeSentencesCount(string text)
        {
            Text = Regex.Replace(text, @"[?]+", "?");
        }

        public void Process()
        {
            CountInterrogativeSentences();
        }

        private void CountInterrogativeSentences()
        {
            Result = "Количество вопросительных предложений: " + Text.Where(ch => ch == '?').ToList().Count.ToString();
        }

        public async Task ProcessAsync()
        {
            await Task.Run(Process);
        }
    }
}