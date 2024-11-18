using Simulator;
namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 10, 20, 10)]  
    [InlineData(25, 10, 20, 20)] 
    [InlineData(15, 10, 20, 15)]
    public void Limiter_ShouldReturnExpectedResult(int value, int min, int max, int expected)
    {
        //Act
        int result = Validator.Limiter(value, min, max);
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hi", 5, 10, '*', "Hi***")]
    [InlineData("Short", 0,3,'-',"Sho")]
    [InlineData("  spaced  ", 5, 10, '*', "Spaced")]
    [InlineData("Long Value    ", 5, 7, '-',"Long Va")]
    [InlineData("", 5, 10, '$', "$$$$$")]
    [InlineData("   ", 5, 7, '*', "*****")]
    [InlineData("Hello World", 5, 11, '*', "Hello World")]

    public void Shortener_ShouldCorrectlyShortenOrPadString
        (string input, int min, int max, char placeholder, string expected)
    {
        // Act
        string result = Validator.Shortener(input, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }


}
