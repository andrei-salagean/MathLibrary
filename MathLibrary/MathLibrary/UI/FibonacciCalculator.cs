using FluentValidation;

namespace MathLibrary.UI;

internal class FibonacciCalculator
{
    private readonly IFibonacciService _fibonacciService;
    private readonly IValidator<string> _validator;

    public FibonacciCalculator(IFibonacciService fibonnaciService, IValidator<string> validator)
    {
        _fibonacciService = fibonnaciService;
        _validator = validator;
    }

    public void RunCalculator()
    {
        Console.WriteLine("Welcome to your fibonnaci calculator, please type which N-th term you would like to compute");

        var term = GetValidInputTerm(_validator);

        var result = _fibonacciService.ComputeNthTerm(term);
        Console.WriteLine($"{term}th Fibonacci number: {result}");
    }

    private static int GetValidInputTerm(IValidator<string> validator)
    {
        var input = Console.ReadLine();

        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        var validationResult = validator.Validate(input);
        if (!validationResult.IsValid)
        {
            throw new Exception(ErrorMessagesHelper.ErrorMessageToFriendlyDisplay(validationResult.Errors));
        }

        return int.Parse(input);
    }
}
