using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using JOS.Enumerations.Microsoft;
using System.Collections.Generic;
using System.Linq;

namespace JOS.Enumeration.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net70)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class EnumerationBenchmark
{
    [BenchmarkCategory("GetAll")]
    [Benchmark(Baseline = true)]
    public IReadOnlyCollection<Hamburger> GetAll_Microsoft()
    {
        return Enumerations.Microsoft.Enumeration.GetAll<Hamburger>().ToList();
    }

    [BenchmarkCategory("GetAll")]
    [Benchmark]
    public IReadOnlyCollection<Enumerations.Ours.Hamburger> GetAll_Ours()
    {
        return Enumerations.Ours.Enumeration.GetAll<Enumerations.Ours.Hamburger>().ToList();
    }

    [BenchmarkCategory("GetAll")]
    [Benchmark]
    public IReadOnlyCollection<Enumerations.Record.Hamburger> GetAll_Record()
    {
        return Enumeration<Enumerations.Record.Hamburger>.GetAll().ToList();
    }

    [BenchmarkCategory("FromName")]
    [Benchmark(Baseline = true)]
    public Hamburger FromName_Microsoft()
    {
        return Enumerations.Microsoft.Enumeration.FromDisplayName<Hamburger>("Cheeseburger");
    }

    [BenchmarkCategory("FromName")]
    [Benchmark]
    public Enumerations.Ours.Hamburger FromName_Ours()
    {
        return Enumerations.Ours.Enumeration.FromDescription<Enumerations.Ours.Hamburger>("Cheeseburger");
    }

    [BenchmarkCategory("FromName")]
    [Benchmark]
    public Enumerations.Record.Hamburger FromName_Record()
    {
        return Enumerations.Record.Hamburger.FromDisplayName("Cheeseburger");
    }

    [BenchmarkCategory("FromValue")]
    [Benchmark(Baseline = true)]
    public Hamburger FromValue_Microsoft()
    {
        return Enumerations.Microsoft.Enumeration.FromValue<Hamburger>(2);
    }

    [BenchmarkCategory("FromValue")]
    [Benchmark]
    public Enumerations.Ours.Hamburger FromValue_Ours()
    {
        return Enumerations.Ours.Enumeration.FromValue<Enumerations.Ours.Hamburger>(2);
    }

    [BenchmarkCategory("FromValue")]
    [Benchmark]
    public Enumerations.Record.Hamburger FromValue_Record()
    {
        return Enumerations.Record.Hamburger.FromValue(2);
    }
}