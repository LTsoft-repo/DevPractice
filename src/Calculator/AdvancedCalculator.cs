using Calculator.Abstractions;
using Calculator.Abstractions.Providers;

namespace Calculator;

public class AdvancedCalculator : BasicCalculator, IAdvancedCalculator
{
    private readonly IAdvancedOperationsProvider advancedOperationsProvider;

    // ReSharper disable once ConvertToPrimaryConstructor
    public AdvancedCalculator( IAdvancedOperationsProvider advancedOperationsProvider )
        : base( advancedOperationsProvider )
    {
        this.advancedOperationsProvider = advancedOperationsProvider;
    }

    public double Exponent( double a, double b )
        => advancedOperationsProvider.Exponent( a, b );
}