using Xunit;
using MyApp;

namespace MyApp.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(10, 20, 30)]
    public void Add_ReturnsCorrectValue(int a, int b, int expected)
    {
        var calc = new Calculator();
        var result = calc.Add(a, b);
        Assert.Equal(expected, result);
    }
}