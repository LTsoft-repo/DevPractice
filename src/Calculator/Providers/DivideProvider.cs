using Calculator.Abstractions;

namespace Calculator.Providers;

public class DivideProvider : IDivideProvider
{
    public virtual double Divide( double a, double b )
        => a / b;
}