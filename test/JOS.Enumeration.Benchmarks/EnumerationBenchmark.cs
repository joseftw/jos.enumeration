using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using JOS.Enumerations.Microsoft;
using System.Collections.Generic;
using System.Linq;

namespace JOS.Enumeration.Benchmarks
{
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
            return Microsoft.Enumeration.GetAll<Hamburger>().ToList();
        }

        [BenchmarkCategory("GetAll")]
        [Benchmark]
        public IReadOnlyCollection<Enumerations.Ours.Hamburger> GetAll_Ours()
        {
            return Ours.Enumeration.GetAll<Enumerations.Ours.Hamburger>().ToList();
        }

        [BenchmarkCategory("GetAll")]
        [Benchmark]
        public IReadOnlyCollection<Enumerations.Record.Hamburger> GetAll_Record()
        {
            return Record.Enumeration<Enumerations.Record.Hamburger>.GetAll().ToList();
        }

        [BenchmarkCategory("FromName")]
        [Benchmark(Baseline = true)]
        public Hamburger FromName_Microsoft()
        {
            return Microsoft.Enumeration.FromDisplayName<Hamburger>("Cheeseburger");
        }

        [BenchmarkCategory("FromName")]
        [Benchmark]
        public Enumerations.Ours.Hamburger FromName_Ours()
        {
            return Ours.Enumeration.FromDescription<Enumerations.Ours.Hamburger>("Cheeseburger");
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
            return Microsoft.Enumeration.FromValue<Hamburger>(2);
        }

        [BenchmarkCategory("FromValue")]
        [Benchmark]
        public Enumerations.Ours.Hamburger FromValue_Ours()
        {
            return Ours.Enumeration.FromValue<Enumerations.Ours.Hamburger>(2);
        }

        [BenchmarkCategory("FromValue")]
        [Benchmark]
        public Enumerations.Record.Hamburger FromValue_Record()
        {
            return Enumerations.Record.Hamburger.FromValue(2);
        }
    }
}
