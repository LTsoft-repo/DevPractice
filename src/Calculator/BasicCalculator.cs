using Calculator.Abstractions;
using Calculator.Abstractions.Providers;

namespace Calculator;

public class BasicCalculator : IBasicCalculator
{
    private readonly IBasicOperationsProvider operationsProvider;

    // ReSharper disable once ConvertToPrimaryConstructor
    public BasicCalculator( IBasicOperationsProvider operationsProvider )
    {
        this.operationsProvider = operationsProvider;
    }

    public double Add( double a, double b )
        => operationsProvider.Add( a, b );

    public double Divide( double a, double b )
        => operationsProvider.Divide( a, b );

    public double Multiply( double a, double b )
        => operationsProvider.Multiply( a, b );

    public double Subtract( double a, double b )
        => operationsProvider.Subtract( a, b );
}