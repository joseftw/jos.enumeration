using BenchmarkDotNet.Running;

namespace JOS.Enumeration.Benchmarks;

internal class Program
{
    public static void Main(string[] args)
    {
        var summary1 = BenchmarkRunner.Run<EnumerationBenchmark>();
    }
}
