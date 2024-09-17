using Calculator.Abstractions;

namespace Calculator.Providers;

public class SubtractProvider : ISubtractProvider
{
    public double Subtract( double a, double b )
        => a - b;
}