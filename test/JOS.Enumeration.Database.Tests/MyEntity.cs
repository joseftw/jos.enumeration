using JOS.Enumerations;
using System;

namespace JOS.Enumeration.Database.Tests;

public class MyEntity
{
    public MyEntity(Guid id, Hamburger hamburger, Car car, Car[] cars)
    {
        Id = id;
        Hamburger = hamburger;
        Car = car;
        Cars = cars;
    }

    public Guid Id { get; }
    public Hamburger Hamburger { get; }
    public Car Car { get; }
    public Car[] Cars { get; }
}
