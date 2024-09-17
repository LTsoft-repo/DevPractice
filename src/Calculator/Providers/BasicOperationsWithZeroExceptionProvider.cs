namespace Calculator.Providers;

public class BasicOperationsWithZeroExceptionProvider : BasicOperationsProvider
{
    public override double Divide( double a, double b )
    {
        if( b == 0 )
        {
            throw new DivideByZeroException( "Can't divide by Zero" );
        }

        return a / b;
    }
}