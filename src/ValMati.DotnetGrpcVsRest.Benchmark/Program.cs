namespace ValMati.DotnetGrpcVsRest.Benchmark
{
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Running;

    public static class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<Benchmark>(
                ManualConfig
                    .Create(DefaultConfig.Instance)
                    .WithOptions(ConfigOptions.DisableOptimizationsValidator));
        }
    }
}