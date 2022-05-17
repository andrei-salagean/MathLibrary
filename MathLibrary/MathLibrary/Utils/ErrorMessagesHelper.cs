using FluentValidation.Results;

namespace MathLibrary.Utils;
internal static class ErrorMessagesHelper
{
    public static string ErrorMessageToFriendlyDisplay(List<ValidationFailure> errors)
    {
        var errorMessages = errors.Select(x => x.ErrorMessage).ToList();

        return string.Join('-', errorMessages);
    }
}
