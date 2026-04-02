using System.Linq;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Benchmarks
{
    public class SubArrayTests : BaseTests
    {
        public const int MEASUREMENT_COUNT = 100;
        public static bool[] Targets;
        public static int TargetRange;

        public void Init(int size, int range)
        {
            Targets = new bool[size];
            TargetRange = range;
        }
        public void Exit(int size, int range)
        {
            Assert.AreEqual(Targets.Length, size);
            Assert.AreEqual(Targets.Count(t => t == true), range);
        }

        [Test, Performance]
        public void RandomIndexesThenInit([Values(100000, 1000000)] int t1, [Values(33333, 66666, 99999)] int t2)
        {
            Measure.Method(DoRandomIndexesThenInit)
                .MeasurementCount(MEASUREMENT_COUNT)
                .SetUp(() => Init(t1, t2))
                .CleanUp(() => Exit(t1, t2))
                .Run();
        }

        void DoRandomIndexesThenInit()
        {
            foreach (int i in Enumerable.Range(0, Targets.Length - 1).ToArray().Shuffle().Take(TargetRange))
                Targets[i] = true;
        }

        [Test, Performance]
        public void InitThenShuffle([Values(100000, 1000000)] int t1, [Values(33333, 66666, 99999)] int t2)
        {
            Measure.Method(DoInitThenShuffle)
                .MeasurementCount(MEASUREMENT_COUNT)
                .SetUp(() => Init(t1, t2))
                .CleanUp(() => Exit(t1, t2))
                .Run();
        }

        void DoInitThenShuffle()
        {
            for (int i = 0; i < TargetRange; i++) Targets[i] = true;
            Targets.Shuffle();
        }
    }
}