using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using System.Collections.Generic;
using System.Linq;
using HamburgerGenerated = JOS.Enumerations.Hamburger;
using HamburgerGeneric = JOS.Enumeration.Benchmarks.Hamburger;

namespace JOS.Enumeration.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net70)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class EnumerationBenchmark
{
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("GetAll")]
    public IReadOnlyCollection<HamburgerGeneric> Generic_GetAll()
    {
        return HamburgerGeneric.GetAll().ToList();
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("GetEnumerable")]
    public IReadOnlyCollection<HamburgerGeneric> Generic_GetEnumerable()
    {
        return HamburgerGeneric.GetEnumerable().ToList();
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("FromDisplayName")]
    public HamburgerGeneric Generic_FromDisplayName()
    {
        return HamburgerGeneric.FromDisplayName("Cheeseburger");
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("FromValue")]
    public HamburgerGeneric Generic_FromValue()
    {
        return HamburgerGeneric.FromValue(2);
    }

    [Benchmark]
    [BenchmarkCategory("GetAll")]
    public IReadOnlyCollection<HamburgerGenerated> Generated_GetAll()
    {
        return HamburgerGenerated.GetAll();
    }

    [Benchmark]
    [BenchmarkCategory("GetEnumerable")]
    public IReadOnlyCollection<HamburgerGenerated> Generated_GetEnumerable()
    {
        return HamburgerGenerated.GetEnumerable().ToList();
    }

    [Benchmark]
    [BenchmarkCategory("FromDisplayName")]
    public HamburgerGenerated Generated_FromDisplayName()
    {
        return HamburgerGenerated.FromDisplayName("Cheeseburger");
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
