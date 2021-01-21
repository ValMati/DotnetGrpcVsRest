namespace ValMati.Dotnet_grpc_vs_rest.Domain.Abstractions
{
    using System.Threading.Tasks;
    using ValMati.Dotnet_grpc_vs_rest.Domain.Requests;

    public interface IEchoService
    {
        public Task<byte[]> EchoAsync(EchoRequest echoRequest);
    }
}