using System.Runtime.InteropServices;
using DynamisAI.BehaviorTreeModule;
using DynamisAI.BehaviorTreeModule.DebugBehaviors;
using NUnit.Framework;

namespace DynamisAITest.BehaviorTreeModule;

public class RepeatTest
{
    
    [SetUp]
    public void Setup()
    {

    }
    
    [Test]
    public void Test1()
    {
        string? message = null;
        
        var root = new Root();
        var repeat = new Repeat(3);
        var action = new DebugAction(() =>
        {
            message = "Hello";
            return true;
        });
        root.SetChild(repeat);
        repeat.SetChild(action);
        
        var status = root.Tick();
        Assert.AreEqual(Status.Running, status);
        Assert.AreEqual(Status.Running, root.Status);
        Assert.AreEqual(Status.Running, repeat.Status);
        Assert.AreEqual(Status.Success, action.Status);

        while (root.Status == Status.Running)
        {
            status = root.Tick();
            Assert.AreEqual(Status.Running, root.Status);
            Assert.AreEqual(Status.Running, repeat.Status);
            Assert.AreEqual(Status.Success, action.Status);
            
            status = root.Tick();
            Assert.AreEqual(Status.Success, root.Status);
            Assert.AreEqual(Status.Success, repeat.Status);
            Assert.AreEqual(Status.Success, action.Status);
        }
    }

    [Test]
    public void Test2()
    {
        var root = new Root();
        root.Tick();
        Assert.AreEqual(Status.Invalid, root.Status);

        var repeat = new Repeat();
        repeat.Tick();
        Assert.AreEqual(Status.Invalid, repeat.Status);
    }
}