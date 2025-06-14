using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class SwapbackTests
{
    const int TARGET_SIZE = 99999;
    static List<int> Targets = new();

    [SetUp]
    public void Init()
    {
        Targets = Enumerable.Range(1, TARGET_SIZE).ToList();
    }

    [Test]
    public void RemoveAt()
    {
        while (Targets.Count > 0)
            Targets.RemoveAt(0);

        Assert.AreEqual(0, Targets.Count);
    }

    [Test]
    public void RemoveBySwap()
    {
        while (Targets.Count > 0)
            Targets.RemoveBySwap(0);

        Assert.AreEqual(0, Targets.Count);
    }
}