namespace DynamisAI.BehaviorTreeModule
{
    public abstract class Behavior
    {
        public Status Status { get; private set; }

        #region Virtual Functions

        public virtual void OnEnter() {}
        public virtual void OnExit(Status status) {}
        public abstract Status Update();
        
        #endregion

        #region Public Functions
        
        public Status Tick()
        {
            if (Status != Status.Running)
            {
                OnEnter();
            }

            Status = Update();

            if (Status != Status.Running)
            {
                OnExit(Status);
            }

            return Status;
        }

        public void Reset()
        {
            Status = Status.Invalid;
        }

        public void Abort()
        {
            OnExit(Status.Aborted);
            Status = Status.Aborted;
        }

        public bool IsEnd()
        {
            return Status is Status.Success or Status.Failure;
        }

        public bool IsRunning()
        {
            return Status == Status.Running;
        }
        
        #endregion
    }
}