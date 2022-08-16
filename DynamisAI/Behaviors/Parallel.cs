namespace DynamisAI.Behaviors;

public class Parallel : Composite
{
    public enum Policy
    {
        RequireOne,
        RequireAll
    }

    public Policy policy;

    public Parallel(Policy policy = Policy.RequireOne)
    {
        this.policy = policy;
    }

    public override Status Update()
    {
        var successCount = 0;
        var failureCount = 0;

        foreach (var child in children)
        {
            if (child.Status == Status.Invalid)
            {
                return Status.Invalid;
            }

            if (child.IsEnd())
            {
                continue;
            }

            var status = child.Tick();

            switch (status)
            {
                case Status.Success:
                    successCount += 1;
                    break;
                case Status.Failure:
                    failureCount += 1;
                    break;
                case Status.Running:
                    break;
                case Status.Invalid:
                default:
                    return Status.Invalid;
            }
        }

        switch (policy)
        {
            case Policy.RequireAll:
                if (failureCount == children.Count)
                {
                    return Status.Failure;
                }
                if (successCount == children.Count)
                {
                    return Status.Success;
                }
                break;
            case Policy.RequireOne:
                if (failureCount >= 1)
                {
                    return Status.Failure;
                }
                if (successCount >= 1)
                {
                    return Status.Success;
                }
                break;
        }

        return Status.Running;
    }
}