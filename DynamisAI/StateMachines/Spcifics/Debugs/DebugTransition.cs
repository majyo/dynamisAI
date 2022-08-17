namespace DynamisAI.StateMachines.Spcifics.Debugs;

public class DebugTransition : Transition
{
    public Func<bool>? transitionHandler;

    public DebugTransition(State target) : base(target)
    {
    }

    public override bool ShouldTransition()
    {
        if (transitionHandler == null)
        {
            return false;
        }

        return transitionHandler.Invoke();
    }
}