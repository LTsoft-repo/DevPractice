using Calculator.Abstractions.Operations;

namespace Calculator.Abstractions;

public interface IBasicCalculator : IAddOperation, ISubtractOperation, IMultiplyOperation, IDivideOperation;

public interface IAdvancedCalculator : IBasicCalculator, IExponentOperation;