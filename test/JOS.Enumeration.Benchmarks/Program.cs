using BenchmarkDotNet.Running;

namespace JOS.Enumeration.Benchmarks;

internal class Program
{
    public static void Main(string[] args)
    {
        _ = BenchmarkRunner.Run<EnumerationBenchmark>();
    }
}
