namespace Metrics.Models
{
    public class Filter
    {
        public bool MostUsedSymbols { get; set; }
        public bool SymbolsCount { get; set; }
        public bool WordsCount { get; set; }
        public bool ExclamatorySentencesCount { get; set; }
        public bool InterrogativeSentencesCount { get; set; }
        public bool LettersCount { get; set; }
    }
}