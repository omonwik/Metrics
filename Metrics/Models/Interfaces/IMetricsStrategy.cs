using System.Threading.Tasks;

namespace WebApplication3.Models.Interfaces
{
    public interface IMetricsStrategy
    {
        string Text { get; }
        string Result { get; }
        string Process();
        Task ProcessAsync();
    }
}
