using Metrics.Models.Interfaces;
using System.Threading.Tasks;

namespace Metrics.Models.MetricStrategies
{
    public abstract class MetricStrategy : IMetricsStrategy
    {
        public string Text { get; protected set; }
        public string Result { get; protected set; }
        public abstract string Predicate { get; protected set; }

        public abstract void Process();

        public async Task ProcessAsync()
        {
            await Task.Run(Process);
        }
    }
}