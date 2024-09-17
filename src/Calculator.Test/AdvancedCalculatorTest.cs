using Calculator.Providers;

namespace Calculator.Test;

public class AdvancedCalculatorTest
{
    #region Exxpont
    [ Fact ]
    public void Exponent_CorrectParameters_Successes()
    {
        // Arrange
        var addProvider = new AddProvider();
        var subtractProvider = new SubtractProvider();
        var multiplyProvider = new MultiplyProvider();
        var divideProvider = new DivideWithExceptionProvider();
        var exponentProvider = new ExponentProvider();
        var calculator = new AdvancedCalculator( addProvider, subtractProvider, multiplyProvider, divideProvider, exponentProvider );

        // Act
        var result = calculator.Exponent( 2, 2 );

        // Assert
        result.Should().Be( 4 );
    }
    #endregion
}