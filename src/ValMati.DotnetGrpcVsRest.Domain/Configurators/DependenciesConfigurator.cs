namespace ValMati.DotnetGrpcVsRest.Domain.Configurators
{
    using Microsoft.Extensions.DependencyInjection;
    using ValMati.DotnetGrpcVsRest.Domain.Abstractions;

    public static class DependenciesConfigurator
    {
        public static void AddDomainDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IEchoService, EchoService>();
        }
    }
}