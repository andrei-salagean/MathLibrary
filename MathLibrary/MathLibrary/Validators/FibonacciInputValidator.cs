using FluentValidation;

namespace MathLibrary.Validators;
public class FibonacciInputValidator : AbstractValidator<string>
{
    public FibonacciInputValidator()
    {
        RuleFor(input => input)
            .MinimumLength(1).WithMessage("Input cannot be empty")
            .NotEqual("0").WithMessage("Nth term has to be at least 1")
            .Must(BeANumber).WithMessage("The input has to be a number");
    }

    private static bool BeANumber(string input)
    {
        return int.TryParse(input, out var _);
    }
}
