using Calculator.Abstractions;

namespace Calculator;

public class AdvancedCalculator : BasicCalculator, IAdvancedCalculator
{
    private readonly IExponentProvider exponentProvider;

    // ReSharper disable once ConvertToPrimaryConstructor
    public AdvancedCalculator(
        IAddProvider addProvider,
        ISubtractProvider subtractProvider,
        IMultiplyProvider multiplyProvider,
        IDivideProvider divideProvider,
        IExponentProvider exponentProvider ) : base( addProvider, subtractProvider, multiplyProvider, divideProvider )
    {
        this.exponentProvider = exponentProvider;
    }

    public double Exponent( double a, double b )
        => exponentProvider.Exponent( a, b );
}