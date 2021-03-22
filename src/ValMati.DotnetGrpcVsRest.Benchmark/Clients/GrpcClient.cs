namespace ValMati.DotnetGrpcVsRest.Benchmark.Clients
{
    using System;
    using System.Threading.Tasks;
    using Grpc.Net.Client;
    using ValMati.DotnetGrpcVsRest.GRPC.Shared;

    public class GrpcClient : IClient
    {
        private readonly GrpcEcho.GrpcEchoClient client;

        public GrpcClient()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var channel = GrpcChannel.ForAddress(
                                        Urls.GRPCURL,
                                        new GrpcChannelOptions { MaxReceiveMessageSize = null });
            client = new GrpcEcho.GrpcEchoClient(channel);
        }

        public async Task CallEchoAsync(int size)
        {
            var request = new GrpcEchoRequest
            {
                Size = size
            };

            await client.EchoAsync(request);
        }
    }
}