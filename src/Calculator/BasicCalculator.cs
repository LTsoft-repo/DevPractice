using Calculator.Abstractions;

namespace Calculator;

public class BasicCalculator : IBasicCalculator
{
    private readonly IAddProvider addProvider;
    private readonly IMultiplyProvider multiplyProvider;
    private readonly ISubtractProvider subtractProvider;
    private readonly IDivideProvider divideProvider;

    // ReSharper disable once ConvertToPrimaryConstructor
    public BasicCalculator(
        IAddProvider addProvider,
        ISubtractProvider subtractProvider,
        IMultiplyProvider multiplyProvider,
        IDivideProvider divideProvider )
    {
        this.addProvider = addProvider;
        this.subtractProvider = subtractProvider;
        this.multiplyProvider = multiplyProvider;
        this.divideProvider = divideProvider;
    }

    public double Add( double a, double b )
        => addProvider.Add( a, b );

    public double Divide( double a, double b )
        => divideProvider.Divide( a, b );

    public double Multiply( double a, double b )
        => multiplyProvider.Multiply( a, b );

    public double Subtract( double a, double b )
        => subtractProvider.Subtract( a, b );
}