using JOS.Enumerations;
using System;

namespace JOS.Enumeration.Database.Tests;

public class MyEntity
{
    public MyEntity(Guid id, Hamburger hamburger, Car car)
    {
        Id = id;
        Hamburger = hamburger;
        Car = car;
    }

    public Guid Id { get; }
    public Hamburger Hamburger { get; }
    public Car Car { get; }
}
