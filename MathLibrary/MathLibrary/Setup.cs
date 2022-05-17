using FluentValidation;

namespace MathLibrary;
internal static class Setup
{
    public static ServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        services.RegisterServices();

        var serviceProvider = services.BuildServiceProvider();
        
        return serviceProvider;
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<FibonacciCalculator>();
        services.AddSingleton<IFibonacciService, FibonacciService>();

        services.AddValidatorsFromAssemblyContaining<Program>();
    }
}
