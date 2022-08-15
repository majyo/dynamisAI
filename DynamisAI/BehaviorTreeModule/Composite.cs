namespace DynamisAI.BehaviorTreeModule
{
    public abstract class Composite : Behavior
    {
        protected int currentChildIndex;
        protected readonly List<Behavior> children = new();

        public Behavior? CurrentChild
        {
            get
            {
                if (currentChildIndex < 0 || currentChildIndex >= children.Count)
                {
                    return null;
                }

                return children[currentChildIndex];
            }
        }

        public void AddChild(Behavior behavior)
        {
            children.Add(behavior);
        }

        public bool RemoveChild(Behavior behavior)
        {
            return children.Remove(behavior);
        }

        public void ClearChildren()
        {
            children.Clear();
        }

        public bool IsCurrentLastChild()
        {
            return currentChildIndex >= children.Count - 1;
        }
    }
}
