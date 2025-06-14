using NUnit.Framework;

public class StateTests
{
    public record Target(State State, State.EState Index);

    static readonly Target[] Targets = {
        new(State.EMPTY, State.EState.EMPTY),
        new(State.PREFILLED, State.EState.PREFILLED),
        new(State.FILLED, State.EState.FILLED),
        new(State.ERROR, State.EState.ERROR)
    };

    [OneTimeSetUp]
    public void Init() => Assert.AreEqual(Targets.Length, 4);

    [Test]
    public void Creations([Values] State.EState i)
    {
        Assert.DoesNotThrow(() => State.Get(i));
    }

    [Test]
    public void TypesCheck([ValueSource(nameof(Targets))] Target t)
    {
        Assert.IsNotNull(t.State);
        Assert.AreEqual($"{t.State.GetType()}", "State");
    }

    [Test]
    public void Comparisons([ValueSource(nameof(Targets))] Target t, [Values] State.EState i)
    {
        if (t.Index == i)
            Assert.AreEqual(t.State, State.Get(i));
        else
            Assert.AreNotEqual(t.State, State.Get(i));
    }
}
