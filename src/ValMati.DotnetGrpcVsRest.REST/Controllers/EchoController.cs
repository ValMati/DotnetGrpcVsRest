namespace ValMati.DotnetGrpcVsRest.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ValMati.DotnetGrpcVsRest.Domain.Abstractions;
    using ValMati.DotnetGrpcVsRest.Domain.Requests;
    using ValMati.DotnetGrpcVsRest.REST.Shared.Requests;

    [ApiController]
    [Route("[controller]")]
    public class EchoController : ControllerBase
    {
        private readonly ILogger<EchoController> _logger;
        private readonly IEchoService _echoService;

        public EchoController(
            ILogger<EchoController> logger,
            IEchoService echoService)
        {
            _logger = logger;
            _echoService = echoService;
        }

        [HttpPost]
        public async Task<ActionResult<byte[]>> GetSimple([FromBody] RestEchoRequest restEchoRequest)
        {
            _logger.LogInformation($"Echo with size '{restEchoRequest.Size}'");

            var echoRequest = new EchoRequest
            {
                Size = restEchoRequest.Size
            };

            var response = await _echoService.EchoAsync(echoRequest);

            return Ok(response);
        }
    }
}