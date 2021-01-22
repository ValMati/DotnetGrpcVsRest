namespace ValMati.Dotnet_grpc_vs_rest.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ValMati.Dotnet_grpc_vs_rest.Domain.Abstractions;
    using ValMati.Dotnet_grpc_vs_rest.Domain.Requests;

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
        public async Task<ActionResult<byte[]>> GetSimple([FromBody] EchoRequest echoRequest)
        {
            _logger.LogInformation($"Echo with size '{echoRequest.Size}' and delay of {echoRequest.Delay} miliseconds");

            var response = await _echoService.EchoAsync(echoRequest);

            return Ok(response);
        }
    }
}