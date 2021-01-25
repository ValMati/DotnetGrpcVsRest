namespace ValMati.DotnetGrpcVsRest.GRPC.GrpcServices
{
    using System.Threading.Tasks;
    using Google.Protobuf;
    using Grpc.Core;
    using Microsoft.Extensions.Logging;
    using ValMati.DotnetGrpcVsRest.Domain.Abstractions;
    using ValMati.DotnetGrpcVsRest.Domain.Requests;

    public class GrpcEchoService : GrpcEcho.GrpcEchoBase
    {
        private readonly ILogger<GrpcEchoService> _logger;
        private readonly IEchoService _echoService;

        public GrpcEchoService(
            ILogger<GrpcEchoService> logger,
            IEchoService echoService)
        {
            _logger = logger;
            _echoService = echoService;
        }

        public override async Task<GrpcEchoResponse> EchoAsync(GrpcEchoRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Echo with size '{request.Size}' and delay of {request.Delay} miliseconds");

            var echoRequest = new EchoRequest
            {
                Delay = request.Delay,
                Size = request.Size
            };

            var response = await _echoService.EchoAsync(echoRequest);

            return new GrpcEchoResponse { Bytes = ByteString.CopyFrom(response) };
        }
    }
}