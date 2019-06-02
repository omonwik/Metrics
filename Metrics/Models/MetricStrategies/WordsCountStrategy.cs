using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Metrics.Models.Interfaces;

namespace Metrics.Models
{
    public class WordsCountStrategy : IMetricsStrategy
    {
        public string Text { get; }

        public string Result { get; private set; }

        public WordsCountStrategy(string text)
        {
            Text = Regex.Replace(text, @"\s+", " ");
        }

        public void Process()
        {
            CalculateWordsCount();
        }

        private void CalculateWordsCount()
        {
            Result = "Количество слов в тексте: " + Text.Split(new char[] { ' ' }).Length.ToString();
        }

        public async Task ProcessAsync()
        {
            await Task.Run(Process);
        }
    }
}