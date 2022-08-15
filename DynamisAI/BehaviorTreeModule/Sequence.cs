namespace DynamisAI.BehaviorTreeModule
{
    public class Sequence : Composite
    {
        public override void OnEnter()
        {
            currentChildIndex = 0;
        }

        public override Status Update()
        {
            if (children.Count == 0)
            {
                return Status.Invalid;
            }
            
            while (CurrentChild != null)
            {
                var status = CurrentChild.Tick();
                switch (status)
                {
                    case Status.Success:
                        currentChildIndex += 1;
                        continue;
                    case Status.Running:
                    case Status.Failure:
                    case Status.Invalid:
                        return status;
                    default:
                        return Status.Invalid;
                }
            }

            return Status.Success;
        }
    }
}