namespace MathLibrary.Services;
public class FibonacciService : IFibonacciService
{
    private const int StartingPosition = 0;

    public string ComputeNthTerm(int term)
    {
        var maxIntFibonacciTerm = 47;

        var nthTermResult = term > maxIntFibonacciTerm
            ? ComputeNthLongTerm(term)
            : ComputeNthSmallTerm(term).ToString();

        return nthTermResult;
    }

    private static int ComputeNthSmallTerm(int term)
    {
        var previousTermValue = 0;

        if (term == 1)
        {
            return previousTermValue;
        }

        var currentTermValue = 1;

        for (var currentTerm = 3; currentTerm <= term; currentTerm++)
        {
            var nextTermValue = previousTermValue + currentTermValue;
            previousTermValue = currentTermValue;
            currentTermValue = nextTermValue;
        }

        return currentTermValue;
    }

    private static string ComputeNthLongTerm(int term)
    {
        var previousTermValue = new List<int>() { 0 };

        if (term == 1)
        {
            return DisplayListAsNumber(previousTermValue);
        }

        var currentTermValue = new List<int>() { 1 };

        for (var currentTerm = 3; currentTerm <= term; currentTerm++)
        {
            var nextTermValue = SumLargeNumbers(previousTermValue, currentTermValue);
            previousTermValue = currentTermValue;
            currentTermValue = nextTermValue;
        }
        
        return DisplayListAsNumber(currentTermValue);
    }

    private static string DisplayListAsNumber(IEnumerable<int> digits)
    {
        var listAsNumber = string.Empty;
        
        foreach(var digit in digits)
        {
            listAsNumber += digit;
        }

        return listAsNumber;
    }
    
    private static List<int> SumLargeNumbers(List<int> firstNumber, List<int> secondNumber)
    {
        var sum = new List<int>();

        if (firstNumber.Count != secondNumber.Count)
        {
            firstNumber = AddZerosToMatchLength(firstNumber, secondNumber.Count);
            secondNumber = AddZerosToMatchLength(secondNumber, firstNumber.Count);
        }

        var carry = 0;

        for (var idx = firstNumber.Count - 1; idx >= 0; idx--)
        {
            var digitSum = firstNumber[idx] + secondNumber[idx] + carry;

            carry = digitSum > 9 ? 1 : 0;

            digitSum %= 10;

            sum.Insert(StartingPosition, digitSum);
        }

        if (carry == 1)
        {
            sum.Insert(StartingPosition, carry);
        }

        return sum;
    }

    private static List<int> AddZerosToMatchLength(List<int> number, int length)
    {
        var valueToAdd = 0;

        for (var idx = number.Count; idx < length; idx++)
        {
            number.Insert(StartingPosition, valueToAdd);
        }

        return number;
    }
}
