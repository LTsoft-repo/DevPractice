using Calculator.Providers;

namespace Calculator.Test;

public class AdvancedCalculatorTest
{
    #region Add
    [ Fact ]
    public void Add_CorrectParameters_Successes()
    {
        // Arrange
        var advancedOperationsProvider = new AdvancedOperationsProvider();
        var calculator = new AdvancedCalculator( advancedOperationsProvider );

        // Act
        var result = calculator.Add( 1, 2 );

        // Assert
        result.Should().Be( 3 );
    }
    #endregion

    #region Subtract
    [ Fact ]
    public void Subtract_CorrectParameters_Successes()
    {
        // Arrange
        var advancedOperationsProvider = new AdvancedOperationsProvider();
        var calculator = new AdvancedCalculator( advancedOperationsProvider );

        // Act
        var result = calculator.Subtract( 1, 2 );

        // Assert
        result.Should().Be( -1 );
    }
    #endregion

    #region Multiply
    [ Fact ]
    public void Multiply_CorrectParameters_Successes()
    {
        // Arrange
        var advancedOperationsProvider = new AdvancedOperationsProvider();
        var calculator = new AdvancedCalculator( advancedOperationsProvider );

        // Act
        var result = calculator.Multiply( 1, 2 );

        // Assert
        result.Should().Be( 2 );
    }
    #endregion

    #region Divide
    [ Fact ]
    public void Divide_CorrectParameters_Successes()
    {
        // Arrange
        var advancedOperationsProvider = new AdvancedOperationsProvider();
        var calculator = new AdvancedCalculator( advancedOperationsProvider );

        // Act
        var result = calculator.Divide( 1, 2 );

        // Assert
        result.Should().Be( 0.5 );
    }

    [ Fact ]
    public void Divide_ByZero_Successes()
    {
        // Arrange
        var advancedOperationsProvider = new AdvancedOperationsProvider();
        var calculator = new AdvancedCalculator( advancedOperationsProvider );

        // Act
        var act = () => calculator.Divide( 1, 0 );

        // Assert
        act.Should().Throw<DivideByZeroException>()
            .WithMessage( "Can't divide by Zero" );
    }
    #endregion

    #region Exponent
    [ Fact ]
    public void Exponent_CorrectParameters_Successes()
    {
        // Arrange
        var advancedOperationsProvider = new AdvancedOperationsProvider();
        var calculator = new AdvancedCalculator( advancedOperationsProvider );

        // Act
        var result = calculator.Exponent( 2, 2 );

        // Assert
        result.Should().Be( 4 );
    }
    #endregion
}