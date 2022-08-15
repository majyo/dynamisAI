namespace DynamisAI.BehaviorTreeModule
{
    public abstract class Decorator : Behavior
    {
        protected Behavior? child;

        public void SetChild(Behavior? behavior)
        {
            child = behavior;
        }

        public override void Abort()
        {
            base.Abort();
            child?.Abort();
        }
    }
}