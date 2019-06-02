using System.Collections.Generic;
using System.Threading.Tasks;
using Metrics.Models;
using Metrics.Models.Interfaces;

namespace Metrics.Services
{
    public class MetricsProcessService : IMetricsProcessService
    {
        private readonly IMetricsProcessEngine _metricsProcessEngine;

        public MetricsProcessService(IMetricsProcessEngine metricsProcessEngine)
        {
            _metricsProcessEngine = metricsProcessEngine;
        }

        public async Task<IEnumerable<string>> Process(Text text)
        {
            var strategies = FilterMetricStrategies(text);
            var result = await _metricsProcessEngine.ProcessMetricsAsync(strategies);

            return result;
        }

        private List<IMetricsStrategy> FilterMetricStrategies(Text text)
        {
            var strategies = new List<IMetricsStrategy>();

            if (text.Filters.ExclamatorySentencesCount) strategies.Add(new ExclamatorySentencesCount(text.Content));
            if (text.Filters.InterrogativeSentencesCount) strategies.Add(new InterrogativeSentencesCount(text.Content));
            if (text.Filters.MostUsedSymbols) strategies.Add(new MostUsedSymbolStrategy(text.Content));
            if (text.Filters.SymbolsCount) strategies.Add(new SymbolsCountStrategy(text.Content));
            if (text.Filters.WordsCount) strategies.Add(new WordsCountStrategy(text.Content));
            if (text.Filters.LettersCount) strategies.Add(new LettersCountStrategy(text.Content));

            return strategies;
        }
    }
}