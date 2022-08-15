using DynamisAI.BehaviorTreeModule;
using NUnit.Framework;

namespace DynamisAITest.BehaviorTreeModule;

public class RepeatTest
{
    private Root? _root;
    private Repeat? _repeat;
    private Action? _action;
    private string? _message;
    
    [SetUp]
    public void Setup()
    {
        _root = new Root();
        _repeat = new Repeat(3);
        _action = new DebugAction(() =>
        {
            _message = "Hello";
            return true;
        });
        _root.SetChild(_repeat);
        _repeat.SetChild(_action);
    }
    
    [Test]
    public void Test1()
    {
        if (_root == null || _repeat == null || _action == null)
        {
            return;
        }
        
        var status = _root.Tick();
        Assert.AreEqual(Status.Running, status);
        Assert.AreEqual(Status.Running, _root.Status);
        Assert.AreEqual(Status.Running, _repeat.Status);
        Assert.AreEqual(Status.Success, _action.Status);

        while (_root.Status == Status.Running)
        {
            status = _root.Tick();
            Assert.AreEqual(Status.Running, _root.Status);
            Assert.AreEqual(Status.Running, _repeat.Status);
            Assert.AreEqual(Status.Success, _action.Status);
            
            status = _root.Tick();
            Assert.AreEqual(Status.Success, _root.Status);
            Assert.AreEqual(Status.Success, _repeat.Status);
            Assert.AreEqual(Status.Success, _action.Status);
        }
    }
}