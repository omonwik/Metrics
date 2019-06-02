using System.Threading.Tasks;

namespace Metrics.Models.Interfaces
{
    public interface IMetricsStrategy
    {
        string Text { get; }
        string Result { get; }
        string Process();
        Task ProcessAsync();
    }
}
