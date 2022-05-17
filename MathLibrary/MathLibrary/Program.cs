try
{
    var serviceProvider = Setup.BuildServiceProvider();

    var app = serviceProvider.GetRequiredService<FibonacciCalculator>();

    app.RunCalculator();
}
catch (Exception ex)
{
    Console.WriteLine($"Something went wrong with application during startup, check logs : {ex.Message}");
}