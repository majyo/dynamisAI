namespace DynamisAI.StateMachines;

public abstract class Transition
{
    public State Target { get; }

    public Transition(State target)
    {
        Target = target;
    }
    
    public abstract bool ShouldTransition();
}