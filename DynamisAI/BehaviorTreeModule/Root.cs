namespace DynamisAI.BehaviorTreeModule
{
    public class Root : Behavior
    {
        protected Behavior? child;

        public void SetChild(Behavior? behavior)
        {
            child = behavior;
        }
        
        public override Status Update()
        {
            if (child == null)
            {
                return Status.Invalid;
            }

            return child.Tick();
        }
    }
}