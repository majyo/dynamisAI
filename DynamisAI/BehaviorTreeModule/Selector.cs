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
                    case Status.Aborted:
                        return status;
                    case Status.Invalid:
                    default:
                        throw new Exception("Tick children failed in sequence node.");
                }
            }

            return Status.Failure;
        }
    }
}