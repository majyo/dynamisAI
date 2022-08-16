namespace DynamisAI.Plannings;

public class GAction
{
    public GState preconditions;
    public GState additionEffects;
    public GState deletionEffects;
    public GState deferredAdditionEffects;
    public GState deferredDeletionEffects;
}