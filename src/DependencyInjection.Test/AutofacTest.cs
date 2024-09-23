using Autofac;
using Calculator;
using Calculator.Abstractions;
using Calculator.Abstractions.Providers;
using Calculator.Providers;
using ScSc.Autofac.Extensions;

namespace DependencyInjection.Test;

public class AutofacTest
{
    [ Fact ]
    public void Basic_RegisterAndResolve()
    {
        // Arrange
        var builder = new ContainerBuilder();

        // Act
        builder.RegisterType<BasicOperationsWithZeroExceptionProvider>()
            .As<IBasicOperationsProvider>()
            .As<BasicOperationsWithZeroExceptionProvider>();

        var container = builder.Build();

        var operationsProvider = container.Resolve<IBasicOperationsProvider>();

        // Assert
        var result = operationsProvider.Add( 2, 3 );

        result.Should().Be( 5 );

        var operationsProvider2 = container.Resolve<BasicOperationsWithZeroExceptionProvider>();
        result = operationsProvider2.Add( 2, 3 );

        result.Should().Be( 5 );
    }

    [ Fact ]
    public void Basic_RegisterAndResolveDependencies()
    {
        // Arrange
        var builder = new ContainerBuilder();

        // Act
        builder.RegisterType<IBasicOperationsProvider, BasicOperationsProvider>();
        builder.RegisterType<IBasicCalculator, BasicCalculator>();

        var container = builder.Build();
        var calculator = container.Resolve<IBasicCalculator>();

        // Assert
        calculator.Should().BeOfType<BasicCalculator>();

        var result = calculator.Add( 2, 3 );
        result.Should().Be( 5 );
    }

    [ Fact ]
    public void Basic_RegisterAndResolveDependencies_MultipleRegistrations()
    {
        // Arrange
        var builder = new ContainerBuilder();

        // Act
        builder.RegisterBasicCalculator();

        builder.RegisterType<IBasicOperationsProvider, BasicOperationsWithZeroExceptionProvider>();

        var container = builder.Build();
        var calculator = container.Resolve<IBasicCalculator>();
        var provider = container.Resolve<IBasicOperationsProvider>();

        // Assert
        calculator.Should().BeOfType<BasicCalculator>();
        provider.Should().BeOfType<BasicOperationsWithZeroExceptionProvider>();

        var result = calculator.Add( 2, 3 );
        result.Should().Be( 5 );
    }

    [ Fact ]
    public async Task Basic_RegisterWithFactory()
    {
        // I called it Factory, but the actual name is Delegate

        // Arrange
        var builder = new ContainerBuilder();

        // Act
        builder.RegisterType<IBasicOperationsProvider, BasicOperationsProvider>();

        builder.Register<CalculatorWithName>( serviceCollection =>
                {
                    // This is a factory method that will be called each time a new instance of INamedBasicCalculator is resolved
                    var provider = serviceCollection.Resolve<IBasicOperationsProvider>();

                    return new( $"My Calculator {DateTime.Now:O}", provider );
                } )
            .As<INamedBasicCalculator>();

        var container = builder.Build();

        var calculator1 = container.Resolve<INamedBasicCalculator>();
        await Task.Delay( 100 );
        var calculator2 = container.Resolve<INamedBasicCalculator>();

        // Assert
        calculator1.Should().BeOfType<CalculatorWithName>();

        var result = calculator1.Add( 2, 3 );
        result.Should().Be( 5 );

        var name1 = calculator1.Name;
        var name2 = calculator2.Name;
        name1.Should().NotBe( name2 );
    }

    [ Fact ]
    public async Task Basic_RegisterSpecifyingParameter()
    {
        // Arrange
        var builder = new ContainerBuilder();

        // Act
        builder.RegisterType<IBasicOperationsProvider, BasicOperationsProvider>();

        // This does the same as the previous test, but it specifies the parameter by name, leaving Autofac to resolve the rest of them.
        builder.RegisterType<CalculatorWithName>()
            .WithParameter( "name", $"My Calculator {DateTime.Now:O}" )
            .As<INamedBasicCalculator>();

        var container = builder.Build();

        var calculator1 = container.Resolve<INamedBasicCalculator>();
        await Task.Delay( 100 );
        var calculator2 = container.Resolve<INamedBasicCalculator>();

        // Assert
        calculator1.Should().BeOfType<CalculatorWithName>();

        var result = calculator1.Add( 2, 3 );
        result.Should().Be( 5 );

        var name1 = calculator1.Name;
        var name2 = calculator2.Name;
        // The difference is that the name will be the same for every instance, since it is specified in the registration.
        name1.Should().Be( name2 );
    }

    [ Fact ]
    public async Task Basic_RegisterSingleInstance()
    {
        // Arrange
        var builder = new ContainerBuilder();

        // Act
        builder.RegisterType<IBasicOperationsProvider, BasicOperationsProvider>();

        builder.Register<CalculatorWithName>( serviceCollection =>
                {
                    var provider = serviceCollection.Resolve<IBasicOperationsProvider>();

                    return new( $"My Calculator {DateTime.Now:O}", provider );
                } )
            .As<INamedBasicCalculator>()
            .SingleInstance();

        var container = builder.Build();

        var calculator1 = container.Resolve<INamedBasicCalculator>();
        await Task.Delay( 100 );
        var calculator2 = container.Resolve<INamedBasicCalculator>();

        // Assert
        calculator1.Should().BeOfType<CalculatorWithName>();

        var result = calculator1.Add( 2, 3 );
        result.Should().Be( 5 );

        var name1 = calculator1.Name;
        var name2 = calculator2.Name;
        name1.Should().Be( name2 );
    }
}

public static class CalculatorRegistrationExtensions
{
    public static void RegisterBasicCalculator( this ContainerBuilder builder )
    {
        builder.RegisterType<IBasicOperationsProvider, BasicOperationsProvider>();

        builder.RegisterType<IBasicCalculator, BasicCalculator>();
    }

    public static void RegisterAdvancedCalculator( this ContainerBuilder builder )
    {
        builder.RegisterType<IAdvancedOperationsProvider, AdvancedOperationsProvider>();

        builder.RegisterType<IAdvancedCalculator, AdvancedCalculator>()
            .As<IBasicCalculator>();
    }
}

public interface INamedObject
{
    string Name { get; }
}

public interface INamedBasicCalculator : IBasicCalculator, INamedObject;

public class CalculatorWithName : BasicCalculator, INamedBasicCalculator
{
    public string Name { get; }

    // ReSharper disable once ConvertToPrimaryConstructor
    public CalculatorWithName( string name, IBasicOperationsProvider basicOperationsProvider )
        : base( basicOperationsProvider )
    {
        Name = name;
    }
}