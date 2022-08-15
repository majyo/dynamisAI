namespace DynamisAI.BehaviorTreeModule;

public class Condition : Decorator
{
    public Func<bool>? Predicate { get; set; }

    public Condition(Func<bool>? predicate)
    {
        Predicate = predicate;
    }

    public override Status Update()
    {
        if (child == null)
        {
            return Status.Invalid;
        }
        
        if (Predicate != null && !Predicate.Invoke())
        {
            Abort();
            return Status.Failure;
        }

        return child.Tick();
    }
}
