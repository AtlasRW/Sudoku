using System.Linq;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Benchmarks
{
    public class ShuffleTests : BaseTests
    {
        public const int MEASUREMENT_COUNT = 100;
        public static int[] Targets;

        public void Init(int size) => Targets = Enumerable.Range(1, size).ToArray();
        public void Exit(int size) => Assert.AreNotEqual(Targets, Enumerable.Range(1, size).ToArray());

        [Test, Performance]
        public void FisherYates([Values(1000, 10000, 100000)] int t)
        {
            Measure.Method(() => Targets.Shuffle())
                .MeasurementCount(MEASUREMENT_COUNT)
                .SetUp(() => Init(t))
                .CleanUp(() => Exit(t))
                .Run();
        }

        [Test, Performance]
        public void LinqOrderBy([Values(1000, 10000, 100000)] int t)
        {
            Measure.Method(DoLinqOrderBy)
                .MeasurementCount(MEASUREMENT_COUNT)
                .SetUp(() => Init(t))
                .CleanUp(() => Exit(t))
                .Run();
        }

        void DoLinqOrderBy() => Targets = Targets.OrderBy(v => new System.Random().Next()).ToArray();
    }
}