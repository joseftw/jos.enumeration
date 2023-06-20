using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using System;
using System.Linq;
using HamburgerGenerated = JOS.Enumerations.Hamburger;
using HamburgerGeneric = JOS.Enumeration.Benchmarks.Hamburger;

namespace JOS.Enumeration.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net80)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class EnumerationBenchmark
{
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("GetAll")]
    public int Generic_GetAll()
    {
        var items = HamburgerGeneric.GetAll();
        return items.Sum(item => item.Value);
    }

    [Benchmark]
    [BenchmarkCategory("GetAll")]
    public int Generated_GetAll()
    {
        var items = HamburgerGenerated.GetAll();
        return items.Sum(item => item.Value);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("GetEnumerable")]
    public int Generic_GetEnumerable()
    {
        var iterator = HamburgerGeneric.GetEnumerable();
        return iterator.Sum(item => item.Value);
    }

    [Benchmark]
    [BenchmarkCategory("GetEnumerable")]
    public int Generated_GetEnumerable()
    {
        var iterator = HamburgerGenerated.GetEnumerable();
        return iterator.Sum(item => item.Value);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("FromDisplayName")]
    public HamburgerGeneric Generic_FromDisplayName()
    {
        return HamburgerGeneric.FromDisplayName("Cheeseburger");
    }

    [Benchmark]
    [BenchmarkCategory("FromDisplayName")]
    public HamburgerGenerated Generated_FromDisplayName()
    {
        return HamburgerGenerated.FromDisplayName("Cheeseburger");
    }

    [Benchmark]
    [BenchmarkCategory("FromDisplayName")]
    public HamburgerGenerated Generated_FromDisplayNameSpan()
    {
        return HamburgerGenerated.FromDisplayName("Cheeseburger".AsSpan());
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("FromValue")]
    public HamburgerGeneric Generic_FromValue()
    {
        return HamburgerGeneric.FromValue(2);
    }

    [Benchmark]
    [BenchmarkCategory("FromValue")]
    public HamburgerGenerated Generated_FromValue()
    {
        return HamburgerGenerated.FromValue(2);
    }
}

public record Hamburger : Enumeration<Hamburger>
{
    public static readonly Hamburger Cheeseburger = new (1, "Cheeseburger");
    public static readonly Hamburger BigMac = new(2, "Big Mac");
    public static readonly Hamburger BigTasty = new(3, "Big Tasty");

    private Hamburger(int value, string displayName) : base(value, displayName)
    {
    }
}
