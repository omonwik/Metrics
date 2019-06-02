using System.Threading.Tasks;

namespace Metrics.Models.Interfaces
{
    public interface IMetricsStrategy
    {
        string Text { get; }
        string Result { get; }
        void Process();
        Task ProcessAsync();
    }
}
