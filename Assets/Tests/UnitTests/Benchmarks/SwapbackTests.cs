using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Benchmarks
{
    public class SwapbackTests : BaseTests
    {
        public const int MEASUREMENT_COUNT = 100;
        public static List<int> Targets = new();

        public void Init(int size) => Targets = Enumerable.Range(1, size).ToList();
        public void Exit() => Assert.AreEqual(0, Targets.Count);

        [Test, Performance]
        public void RemoveAt([Values(1000, 10000, 100000)] int t)
        {
            Measure
                .Method(DoRemoveAt)
                .MeasurementCount(MEASUREMENT_COUNT)
                .SetUp(() => Init(t))
                .CleanUp(Exit)
                .Run();
        }

        void DoRemoveAt()
        {
            while (Targets.Count > 0)
                Targets.RemoveAt(0);
        }

        [Test, Performance]
        public void RemoveBySwap([Values(1000, 10000, 100000)] int t)
        {
            Measure
                .Method(DoRemoveBySwap)
                .MeasurementCount(MEASUREMENT_COUNT)
                .SetUp(() => Init(t))
                .CleanUp(Exit)
                .Run();
        }

        void DoRemoveBySwap()
        {
            while (Targets.Count > 0)
                Targets.RemoveBySwap(0);
        }
    }
}