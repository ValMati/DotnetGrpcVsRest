namespace ValMati.DotnetGrpcVsRest.Benchmark.Clients
{
    using System.Threading.Tasks;

    public interface IClient
    {
        Task CallEchoAsync(int size);
    }
}