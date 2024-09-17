using Calculator.Abstractions;

namespace Calculator.Providers;

public class ExponentProvider : IExponentProvider
{
    public double Exponent( double a, double b )
        => Math.Pow( a, b );
}