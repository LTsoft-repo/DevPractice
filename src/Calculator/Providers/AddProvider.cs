using Calculator.Abstractions;

namespace Calculator.Providers;

public class AddProvider : IAddProvider
{
    public double Add( double a, double b )
        => a + b;
}