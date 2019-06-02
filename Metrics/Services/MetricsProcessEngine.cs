using System.Collections.Generic;
using System.Threading.Tasks;
using Metrics.Models.Interfaces;

namespace Metrics.Services
{
    public class MetricsProcessEngine : IMetricsProcessEngine
    {
        public List<string> ProcessMetrics(List<IMetricsStrategy> strategies)
        {
            var result = new List<string>();
            strategies.ForEach(strategy => strategy.Process());
            strategies.ForEach(strategy => result.Add(strategy.Result));
            return result;
        }

        public async Task<List<string>> ProcessMetricsAsync(List<IMetricsStrategy> strategies)
        {
            var tasks = new List<Task>();
            var result = new List<string>();
            strategies.ForEach(strategy => tasks.Add(strategy.ProcessAsync()));

            await Task.WhenAll(tasks);

            strategies.ForEach(strategy => result.Add(strategy.Result));
            return result;
        }
    }
}