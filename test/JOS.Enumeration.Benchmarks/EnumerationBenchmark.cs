using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using JOS.Enumerations;
using System.Collections.Generic;
using System.Linq;

namespace JOS.Enumeration.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net70)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class EnumerationBenchmark
{
    [Benchmark]
    public IReadOnlyCollection<Hamburger> GetAll()
    {
        return Hamburger.GetAll().ToList();
    }

    [Benchmark]
    public Hamburger FromDisplayName_Record()
    {
        return Hamburger.FromDisplayName("Cheeseburger");
    }

    [Benchmark]
    public Hamburger FromValue_Record()
    {
        return Hamburger.FromValue(2);
    }
}
