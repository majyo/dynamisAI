namespace DynamisAI.BehaviorTreeModule;

public class DebugAction : Action
{
    public System.Func<bool>? Func { get; set; }

    public DebugAction()
    {
    }

    public DebugAction(Func<bool>? func)
    {
        Func = func;
    }

    public override Status Update()
    {
        if (Func == null)
        {
            return Status.Success;
        }

        return Func.Invoke() ? Status.Success : Status.Failure;
    }
}