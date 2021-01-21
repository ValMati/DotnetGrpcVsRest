namespace ValMati.Dotnet_grpc_vs_rest.Domain.Configurators
{
    using Microsoft.Extensions.DependencyInjection;
    using ValMati.Dotnet_grpc_vs_rest.Domain.Abstractions;

    public static class DependenciesConfigurator
    {
        public static void AddDomainDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IEchoService, EchoService>();
        }
    }
}