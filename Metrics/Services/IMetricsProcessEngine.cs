using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Models.Interfaces;

namespace WebApplication3.Services
{
    public interface IMetricsProcessEngine
    {
        List<string> ProcessMetrics(List<IMetricsStrategy> strategies);
        Task<List<string>> ProcessMetricsAsync(List<IMetricsStrategy> strategies);
    }
}
