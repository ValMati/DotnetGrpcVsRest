namespace ValMati.DotnetGrpcVsRest.Benchmark
{
    using System;
    using System.Threading.Tasks;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Engines;
    using ValMati.DotnetGrpcVsRest.Benchmark.Clients;

    [SimpleJob(RunStrategy.Throughput)]
    [MedianColumn]
    [Q1Column]
    [Q3Column]
    [RPlotExporter]
    [AsciiDocExporter]
    [CsvExporter]
    [HtmlExporter]
    public class Benchmark
    {
        [ParamsAllValues]
        public ClientType ClientType { get; set; }

        [Params(1, 10)]
        public int Calls { get; set; }

        [Params(0, 100, 10000, 1000000)]
        public int Size { get; set; }

        [Benchmark]
        public async Task Echo()
        {
            IClient client = ClientType switch
            {
                ClientType.REST => new RestClient(),
                ClientType.GRPC => new GrpcClient(),
                _ => throw new NotImplementedException()
            };

            for (int index = 0; index < Calls; index++)
            {
                await client.CallEchoAsync(Size);
            }
        }
    }
}