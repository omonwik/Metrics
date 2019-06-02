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

        public IEnumerable<string> ProcessMetrics(ProcessInfo processInfo)
        {
            var strategies = FilterMetricStrategies(processInfo);
            var result = _metricsProcessEngine.ProcessMetrics(strategies);

            return result;
        }

        public async Task<IEnumerable<string>> ProcessMetricsAsync(ProcessInfo processInfo)
        {
            var strategies = FilterMetricStrategies(processInfo);
            var result = await _metricsProcessEngine.ProcessMetricsAsync(strategies);

            return result;
        }

        private List<IMetricsStrategy> FilterMetricStrategies(ProcessInfo processInfo)
        {
            var strategies = new List<IMetricsStrategy>();

            if (processInfo.Filter.ExclamatorySentencesCount) strategies.Add(new ExclamatorySentencesCountStrategy(processInfo.Text));
            if (processInfo.Filter.InterrogativeSentencesCount) strategies.Add(new InterrogativeSentencesCountStrategy(processInfo.Text));
            if (processInfo.Filter.MostUsedSymbols) strategies.Add(new MostUsedSymbolStrategy(processInfo.Text));
            if (processInfo.Filter.SymbolsCount) strategies.Add(new SymbolsCountStrategy(processInfo.Text));
            if (processInfo.Filter.WordsCount) strategies.Add(new WordsCountStrategy(processInfo.Text));
            if (processInfo.Filter.LettersCount) strategies.Add(new LettersCountStrategy(processInfo.Text));

            return strategies;
        }
    }
}