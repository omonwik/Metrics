using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApplication3.Models.Interfaces;

namespace WebApplication3.Models
{
    public class InterrogativeSentencesCount : IMetricsStrategy
    {
        public string Text { get; }

        public string Result { get; private set; }

        public InterrogativeSentencesCount(string text)
        {
            Text = Regex.Replace(text, @"[?]+", "?");
        }

        public string Process()
        {
            CountInterrogativeSentences();
            return Result;
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