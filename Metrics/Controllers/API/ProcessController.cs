using System.Threading.Tasks;
using System.Web.Http;
using Metrics.Models;
using Metrics.Services;

namespace Metrics.Controllers.API
{
    public class ProcessController : ApiController
    {
        private readonly IMetricsProcessService _metricsProcessService;

        public ProcessController(IMetricsProcessService metricsProcessService)
        {
            _metricsProcessService = metricsProcessService;
        }

        [HttpPost]
        [Route("api/Process")]
        public async Task<IHttpActionResult> Process(Text text)
        {
            var result = await _metricsProcessService.Process(text);
            return Ok(result);
        }
    }
}
