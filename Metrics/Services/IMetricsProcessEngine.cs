using System.Collections.Generic;
using System.Threading.Tasks;
using Metrics.Models.Interfaces;

namespace Metrics.Services
{
    public interface IMetricsProcessEngine
    {
        List<string> ProcessMetrics(List<IMetricsStrategy> strategies);
        Task<List<string>> ProcessMetricsAsync(List<IMetricsStrategy> strategies);
    }
}
