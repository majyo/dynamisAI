namespace DynamisAI.BehaviorTreeModule.DebugBehaviors;

public class DebugAction : Action
{
    public System.Func<bool>? Func { get; set; }
    public int Delay { get; set; } = -1;

    private int _counter = 0;

    public DebugAction()
    {
    }

    public DebugAction(Func<bool>? func)
    {
        Func = func;
    }

    public DebugAction(Func<bool>? func, int delay)
    {
        Func = func;
        Delay = delay;
    }

    public override void OnEnter()
    {
        _counter = 0;
    }

    public override Status Update()
    {
        if (Func == null)
        {
            return Status.Success;
        }

        if (_counter < Delay)
        {
            _counter += 1;
            return Status.Running;
        }

        return Func.Invoke() ? Status.Success : Status.Failure;
    }
}