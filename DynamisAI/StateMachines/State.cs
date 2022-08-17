using DynamisAI.Utils;

namespace DynamisAI.StateMachines;

public abstract class State
{
    public Blackboard? Blackboard { get; set; }
    public string Name { get; set; } = "Default";

    public virtual void OnEnter()
    {
    }

    public virtual void OnExit()
    {
    }

    public virtual void OnUpdate()
    {
    }
}