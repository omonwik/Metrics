using System.Collections.Generic;
using System.Threading.Tasks;
using Metrics.Models;

namespace Metrics.Services
{
    public interface IMetricsProcessService
    {
        Task<IEnumerable<string>> Process(Text text);
    }
}
