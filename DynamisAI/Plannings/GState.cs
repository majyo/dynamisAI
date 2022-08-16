namespace DynamisAI.Plannings;

public class GState
{
    private HashSet<GPredicate> _predicates;

    public GState()
    {
        _predicates = new HashSet<GPredicate>();
    }

    public GState(GState other)
    {
        _predicates = new HashSet<GPredicate>(other._predicates);
    }

    public bool ContainsAll(HashSet<GPredicate> requires)
    {
        foreach (var predicate in requires)
        {
            if (!_predicates.Contains(predicate))
            {
                return false;
            }
        }

        return true;
    }

    public bool ContainsAny(HashSet<GPredicate> requires)
    {
        foreach (var predicate in requires)
        {
            if (_predicates.Contains(predicate))
            {
                return true;
            }
        }

        return false;
    }

    public bool AddPredicate(GPredicate predicate)
    {
        return _predicates.Add(predicate);
    }

    public bool RemovePredicate(GPredicate predicate)
    {
        return _predicates.Remove(predicate);
    }

    public HashSet<GPredicate> GetValues()
    {
        return _predicates;
    }
}