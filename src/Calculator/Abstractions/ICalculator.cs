namespace Calculator.Abstractions;

public interface IBasicCalculator : IAddProvider, ISubtractProvider, IMultiplyProvider, IDivideProvider;

public interface IAdvancedCalculator : IBasicCalculator, IExponentProvider;