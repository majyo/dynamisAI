using DynamisAI.Behaviors;
using DynamisAI.Behaviors.DebugBehaviors;
using NUnit.Framework;

namespace DynamisAITest.BehaviorTreeModule;

public class SequenceTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var sequence = new Sequence();
        sequence.Tick();
        Assert.AreEqual(Status.Invalid, sequence.Status);
        sequence.Reset();
        
        var action1 = new DebugAction(() => true, 1);
        var action2 = new DebugAction(() => true, 1);
        var action3 = new DebugAction(() => false, 1);
        var action4 = new DebugAction(() => false, 1);
        
        sequence.AddChild(action1);
        sequence.AddChild(action2);
        sequence.AddChild(action3);
        sequence.AddChild(action4);

        sequence.Tick();
        Assert.AreEqual(Status.Running, sequence.Status);
        Assert.AreEqual(Status.Running, action1.Status);
        sequence.Tick();
        Assert.AreEqual(Status.Running, sequence.Status);
        Assert.AreEqual(Status.Success, action1.Status);
        Assert.AreEqual(Status.Running, action2.Status);
        sequence.Tick();
        Assert.AreEqual(Status.Running, sequence.Status);
        Assert.AreEqual(Status.Success, action2.Status);
        Assert.AreEqual(Status.Running, action3.Status);
        sequence.Tick();
        Assert.AreEqual(Status.Failure, sequence.Status);
        Assert.AreEqual(Status.Failure, action3.Status);
    }
}