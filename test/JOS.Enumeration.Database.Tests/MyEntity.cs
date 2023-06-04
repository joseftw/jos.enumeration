using JOS.Enumerations;
using System;

namespace JOS.Enumeration.Database.Tests;

public class MyEntity
{
    public MyEntity(Guid id, Hamburger hamburger)
    {
        Id = id;
        Hamburger = hamburger;
    }

    public Guid Id { get; }
    public Hamburger Hamburger { get; }
}
