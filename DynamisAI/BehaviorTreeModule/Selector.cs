namespace DynamisAI.BehaviorTreeModule
{
    public class Selector : Composite
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
                    case Status.Failure:
                        currentChildIndex += 1;
                        continue;
                    case Status.Success:
                    case Status.Running:
                    case Status.Invalid:
                        return status;
                    default:
                        return Status.Invalid;
                }
            }

            return Status.Failure;
        }
    }
}