using Metrics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Metrics.Services
{
    public interface IMetricsProcessService
    {
        IEnumerable<string> ProcessMetrics(ProcessInfo processInfo);
        Task<IEnumerable<string>> ProcessMetricsAsync(ProcessInfo processInfo);
    }
}
