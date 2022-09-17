﻿namespace JOS.Enumeration.Tests.Ours;

internal class Sausage : Enumeration.Ours.Enumeration
{
    public static Sausage HotDog = new(1, "Hot Dog");
    public static Sausage Pølse = new(2, "Pølse");

    private Sausage(int value, string name) : base(value, name)
    {
    }
}