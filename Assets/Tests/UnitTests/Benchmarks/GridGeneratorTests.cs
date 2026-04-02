using System.Collections.Generic;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Benchmarks
{
    public class GridGeneratorTests : BaseTests
    {
        public const int MEASUREMENT_COUNT = 100;
        public List<Cell> Targets;
        public Difficulty TargetDifficulty;

        public void Init(Difficulty difficulty) => TargetDifficulty = difficulty;
        public void Exit() => Logger.Log(Targets);

        [Test, Performance]
        public void GenerateGrid([Values] Difficulty difficulty)
        {
            Measure.Method(DoGenerateGrid)
                .MeasurementCount(MEASUREMENT_COUNT)
                .SetUp(() => Init(difficulty))
                .CleanUp(Exit)
                .Run();
        }

        void DoGenerateGrid() => Targets = GridGenerator.Generate(TargetDifficulty);
    }
}