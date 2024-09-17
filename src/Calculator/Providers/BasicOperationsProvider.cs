using Calculator.Abstractions.Providers;

namespace Calculator.Providers;

public class BasicOperationsProvider : IBasicOperationsProvider
{
    public virtual double Add( double a, double b )
        => a + b;

    public virtual double Subtract( double a, double b )
        => a - b;

    public virtual double Multiply( double a, double b )
        => a * b;

    public virtual double Divide( double a, double b )
        => a / b;
}