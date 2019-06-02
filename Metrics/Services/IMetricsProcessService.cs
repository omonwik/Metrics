using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface IMetricsProcessService
    {
        Task<IEnumerable<string>> Process(Text text);
    }
}
