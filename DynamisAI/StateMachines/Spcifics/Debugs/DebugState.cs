namespace DynamisAI.StateMachines.Spcifics.Debugs;

public class DebugState : State
{
    public Action? onEnterHandler;
    public Action? onExitHandler;
    public Action? onUpdateHandler;

    public override void OnEnter()
    {
        onEnterHandler?.Invoke();
    }

    public override void OnExit()
    {
        onExitHandler?.Invoke();
    }

    public override void OnUpdate()
    {
        onUpdateHandler?.Invoke();
    }
}