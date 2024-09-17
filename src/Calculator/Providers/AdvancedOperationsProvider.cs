using Calculator.Abstractions.Providers;

namespace Calculator.Providers;

public class AdvancedOperationsProvider : BasicOperationsWithZeroExceptionProvider, IAdvancedOperationsProvider
{
    public double Exponent( double a, double b )
        => Math.Pow( a, b );
}