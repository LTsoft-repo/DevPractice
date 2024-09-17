using Calculator.Abstractions;

namespace Calculator.Providers;

public class DivideWithExceptionProvider : IDivideProvider
{
    public double Divide( double a, double b )
    {
        if( b == 0 )
        {
            throw new DivideByZeroException( "Can't divide by Zero" );
        }

        return a / b;
    }
}