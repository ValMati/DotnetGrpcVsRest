namespace ValMati.DotnetGrpcVsRest.Benchmark.Clients
{
    public static class Urls
    {
#if NETCOREAPP3_1
        public const string RESTURL = "https://localhost:9091/echo";
        public const string GRPCURL = "https://localhost:9093";
#elif NET5_0
        public const string RESTURL = "http://localhost:9092/echo";
        public const string GRPCURL = "https://localhost:9094";
#endif
    }
}