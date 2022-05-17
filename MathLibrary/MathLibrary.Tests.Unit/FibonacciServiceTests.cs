using MathLibrary.Services;

namespace MathLibrary.Tests.Unit;
public class FibonacciServiceTests
{
    [Theory]
    [InlineData(1,"0")]
    [InlineData(2,"1")]
    [InlineData(3,"1")]
    [InlineData(4,"2")]
    [InlineData(40, "63245986")]
    [InlineData(47, "1836311903")]
    [InlineData(48, "2971215073")]
    [InlineData(49, "4807526976")]
    public void ComputeNthTerm_ShouldReturnExpectedResult_WhenTermIsComputed(int term, string expectedResult)
    {
        // Arrange
        var sut = new FibonacciService();

        // Act
        var result = sut.ComputeNthTerm(term);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
