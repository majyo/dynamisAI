namespace DynamisAI.Behaviors;

public class Repeat : Decorator
{
    private long _currentCount;
    
    public long Limit { get; set; }
    
    public Repeat(int limit = -1)
    {
        Limit = limit;
    }

    public override void OnEnter()
    {
        _currentCount = 0;
    }

    public override Status Update()
    {
        if (child == null)
        {
            return Status.Invalid;
        }
        
        var status = child.Tick();

        switch (status)
        {
            case Status.Success:
                _currentCount += 1;
                if (Limit >= 0 && _currentCount >= Limit)
                {
                    return Status.Success;
                }
                return Status.Running;
            case Status.Running:
                return Status.Running;
            case Status.Failure:
            case Status.Invalid:
                return status;
            default:
                return Status.Invalid;
        }
    }
}