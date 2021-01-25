namespace ValMati.DotnetGrpcVsRest.Domain.Abstractions
{
    using System.Threading.Tasks;
    using ValMati.DotnetGrpcVsRest.Domain.Requests;

    public interface IEchoService
    {
        public Task<byte[]> EchoAsync(EchoRequest echoRequest);
    }
}