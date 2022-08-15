using System;
using DynamisAI.BehaviorTreeModule;
using DynamisAI.BehaviorTreeModule.DebugBehaviors;
using NUnit.Framework;

namespace DynamisAITest.BehaviorTreeModule;

public class SelectorTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var selector = new Selector();
        selector.Tick();
        Assert.AreEqual(Status.Invalid, selector.Status);
        
        selector.Reset();
        var action1 = new DebugAction(() => false, 1);
        var action2 = new DebugAction(() => false, 1);
        var action3 = new DebugAction(() => true, 1);
        var action4 = new DebugAction(() => true, 1);
        
        selector.AddChild(action1);
        selector.AddChild(action2);
        selector.AddChild(action3);
        selector.AddChild(action4);
        

        selector.Tick();
        Assert.AreEqual(Status.Running, selector.Status);
        Assert.AreEqual(Status.Running, action1.Status);
        selector.Tick();
        Assert.AreEqual(Status.Running, selector.Status);
        Assert.AreEqual(Status.Failure, action1.Status);
        Assert.AreEqual(Status.Running, selector.Status);
        Assert.AreEqual(Status.Running, action2.Status);
        selector.Tick();
        Assert.AreEqual(Status.Running, selector.Status);
        Assert.AreEqual(Status.Failure, action2.Status);
        Assert.AreEqual(Status.Running, selector.Status);
        Assert.AreEqual(Status.Running, action3.Status);
        selector.Tick();
        Assert.AreEqual(Status.Success, selector.Status);
        Assert.AreEqual(Status.Success, action3.Status);
    }
}