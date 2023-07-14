using JOS.Enumerations;
using Shouldly;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace JOS.Enumeration.Tests;

public class CarTests
{
    [Fact]
    public void DifferentInstancesShouldNotBeEqual()
    {
        var spider = Car.FerrariSpider;
        var modelY = Car.TeslaModelY;

        modelY.ShouldNotBeSameAs(spider);
    }


    [Fact]
    public void SameInstancesShouldBeEqual()
    {
        var car1 = Car.FerrariSpider;
        var car2 = CreateCopy(car1);

        car1.Equals(car2).ShouldBeTrue();
    }

    [Fact]
    public void GetAll_ShouldReturnAllInstances()
    {
        var cars = Car.GetAll().ToHashSet();

        cars.Count.ShouldBe(2);
        cars.ShouldContain(Car.FerrariSpider);
        cars.ShouldContain(Car.TeslaModelY);
    }

    [Fact]
    public void GetEnumerable_ShouldReturnAllInstances()
    {
        var enumerable = Car.GetEnumerable();

        var items = enumerable.ToList();

        items.Count.ShouldBe(2);
        items.ShouldContain(Car.FerrariSpider);
        items.ShouldContain(Car.TeslaModelY);
    }

    [Fact]
    public void FromValue_ShouldReturnCorrectInstance()
    {
        var result = Car.FromValue(Car.TeslaModelY.Value);

        result.ShouldBe(Car.TeslaModelY);
    }

    [Fact]
    public void FromValue_ShouldThrowIfNoMatchingItemFound()
    {
        var exception = Should.Throw<InvalidOperationException>(() => Car.FromValue("any"));

        exception.Message.ShouldBe("'any' is not a valid value in 'JOS.Enumerations.Car'");
    }

    [Fact]
    public void FromDescription_ShouldReturnCorrectInstance()
    {
        var result = Car.FromDescription(Car.TeslaModelY.Description);

        result.ShouldBe(Car.TeslaModelY);
    }

    [Fact]
    public void FromDescription_ShouldThrowIfNoMatchingItemFound()
    {
        var exception = Should.Throw<InvalidOperationException>(() => Car.FromDescription("Egg"));

        exception.Message.ShouldBe(
            "'Egg' is not a valid description in 'JOS.Enumerations.Car'");
    }

    [Fact]
    public void Span_FromDescription_ShouldReturnCorrectInstance()
    {
        var description = Car.TeslaModelY.Description.AsSpan();

        var result = Car.FromDescription(description);

        result.ShouldBe(Car.TeslaModelY);
    }

    [Fact]
    public void Span_FromDescription_ShouldThrowIfNoMatchingItemFound()
    {
        var exception = Should.Throw<InvalidOperationException>(() => Car.FromDescription("Egg".AsSpan()));

        exception.Message.ShouldBe(
            "'Egg' is not a valid description in 'JOS.Enumerations.Car'");
    }

    [Fact]
    public void DifferentImplementationsWillNotClash()
    {
        var cars = Car.GetAll().ToList();
        var hamburgers = Hamburger.GetAll().ToList();

        cars.Count.ShouldBe(2);
        hamburgers.Count.ShouldBe(3);
    }

    [Fact]
    public void CompareTo_ShouldReturn0ForSameInstances()
    {
        var car1 = Car.TeslaModelY;
        var car2 = CreateCopy(car1);

        var result = car1.CompareTo(car2);

        result.ShouldBe(0);
    }

    [Fact]
    public void CompareTo_ShouldReturnMinus1ForItemWhenValueIsLessThanTheComparedValue()
    {
        var car1 = Car.FerrariSpider;
        var car2 = Car.TeslaModelY;

        var result = car1.CompareTo(car2);

        result.ShouldBe(-1);
    }

    [Fact]
    public void CompareTo_ShouldReturn1ForItemWhenValueIsGreaterThanTheComparedValue()
    {
        var car1 = Car.TeslaModelY;
        var car2 = Car.FerrariSpider;

        var result = car1.CompareTo(car2);

        result.ShouldBe(1);
    }

    private static Car CreateCopy(Car car)
    {
        return (Car)typeof(Car).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] { typeof(string), typeof(string), typeof(string) }, null)
            !.Invoke(new object[] { car.Value, car.Description, car.Model });
    }
}
