using Calculator.Abstractions;

namespace Calculator.Providers;

public class MultiplyProvider : IMultiplyProvider
{
    public double Multiply( double a, double b )
        => a * b;
}