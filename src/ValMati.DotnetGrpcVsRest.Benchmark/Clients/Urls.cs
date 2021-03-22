namespace ValMati.DotnetGrpcVsRest.Benchmark.Clients
{
    public static class Urls
    {
#if NETCOREAPP3_1
        public const string RESTURL = "http://rest31:9091/echo";
        public const string GRPCURL = "http://grpc31:9093";
#elif NET5_0
        public const string RESTURL = "http://rest31:9092/echo";
        public const string GRPCURL = "http://grpc31:9094";
#endif
    }
}