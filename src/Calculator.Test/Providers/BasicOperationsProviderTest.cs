using Calculator.Providers;

namespace Calculator.Test.Providers;

public class BasicOperationsProviderTest
{
    #region Add
    [ Fact ]
    public void Add_CorrectParameters_Successes()
    {
        // Arrange
        var provider = new BasicOperationsProvider();

        // Act
        var result = provider.Add( 1, 2 );

        // Assert
        result.Should().Be( 3 );
    }
    #endregion

    #region Subtract
    [ Fact ]
    public void Subtract_CorrectParameters_Successes()
    {
        // Arrange
        var provider = new BasicOperationsProvider();

        // Act
        var result = provider.Subtract( 1, 2 );

        // Assert
        result.Should().Be( -1 );
    }
    #endregion

    #region Multiply
    [ Fact ]
    public void Multiply_CorrectParameters_Successes()
    {
        // Arrange
        var provider = new BasicOperationsProvider();

        // Act
        var result = provider.Multiply( 1, 2 );

        // Assert
        result.Should().Be( 2 );
    }
    #endregion

    #region Divide
    [ Fact ]
    public void Divide_CorrectParameters_Successes()
    {
        // Arrange
        var provider = new BasicOperationsProvider();

        // Act
        var result = provider.Divide( 1, 2 );

        // Assert
        result.Should().Be( 0.5 );
    }

    [ Fact ]
    public void Divide_ByZero_Successes()
    {
        // Arrange
        var provider = new BasicOperationsProvider();

        // Act
        var result = provider.Divide( 1, 0 );

        // Assert
        result.Should().Be( double.PositiveInfinity );
    }
    #endregion
}