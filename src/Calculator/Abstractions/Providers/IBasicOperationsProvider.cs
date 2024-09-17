using Calculator.Abstractions.Operations;

namespace Calculator.Abstractions.Providers;

public interface IBasicOperationsProvider : IAddOperation, ISubtractOperation, IMultiplyOperation, IDivideOperation;