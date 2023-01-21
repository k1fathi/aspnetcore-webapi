using AspnetcoreWebapi.Services.Registration;

namespace AspnetcoreWebapi.Refactored.Startup;

public static partial class ServiceInitializer
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        RegisterCustomDependencies(services);

        RegisterSwagger(services);
        RegisterHttpClientDependencies(services);

        return services;
    }

    private static void RegisterCustomDependencies(IServiceCollection services)
    {
        services.AddTransient<IKafkaRegistration, KafkaRegistration>();
        services.AddTransient<IRabbitMQRegistration, RabbitMQRegistration>();
    }

    private static void RegisterHttpClientDependencies(IServiceCollection services)
    {
        services.AddTransient<IKafkaRegistration, KafkaRegistration>();
        services.AddTransient<IRabbitMQRegistration, RabbitMQRegistration>();
    }
    private static void RegisterSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        //services.AddSwaggerGen();
    }
}

