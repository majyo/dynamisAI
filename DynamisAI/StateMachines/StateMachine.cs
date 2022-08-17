using DynamisAI.Utils;

namespace DynamisAI.StateMachines;

public class StateMachine
{
    private HashSet<State> _states;
    private Dictionary<State, List<Transition>> _transitionsMap;
    private Blackboard _blackboard;

    private State? _prevState;
    private State? _currState;

    public StateMachine()
    {
        _states = new HashSet<State>();
        _transitionsMap = new Dictionary<State, List<Transition>>();
        _blackboard = new Blackboard();
    }

    #region State Modification Functions

    public bool AddState(State state)
    {
        var result = _states.Add(state);
        
        if (result)
        {
            state.Blackboard = _blackboard;
        }

        return result;
    }

    public bool RemoveState(State state)
    {
        var result = _states.Remove(state);

        if (result)
        {
            state.Blackboard = null;
        }

        return result;
    }

    public void ClearState()
    {
        foreach (var state in _states)
        {
            state.Blackboard = null;
        }
            
        _states.Clear();
    }
    
    #endregion

    #region Transition Modification Functions

    public void AddTransition(State source, Transition transition)
    {
        if (!_transitionsMap.ContainsKey(source))
        {
            _transitionsMap.Add(source, new List<Transition>());
        }
        
        _transitionsMap[source].Add(transition);
    }

    public bool RemoveTransition(State source, Transition transition)
    {
        var hasTransitions = _transitionsMap.TryGetValue(source, out var transitions);

        if (!hasTransitions || transitions == null)
        {
            return false;
        }

        if (transitions.Count == 0)
        {
            _transitionsMap.Remove(source);
            return false;
        }

        var isTransitionRemoved = transitions.Remove(transition);

        if (transitions.Count == 0)
        {
            _transitionsMap.Remove(source);
        }
        
        return isTransitionRemoved;
    }

    public void ClearTransitions()
    {
        _transitionsMap.Clear();
    }

    #endregion

    #region State Machine Life Cycles

    public void Start(State state)
    {
        _currState = state;
        state.OnEnter();
    }
    
    public void Tick()
    {
        if (_currState == null)
        {
            return;
        }
        
        _currState.OnUpdate();
        var candidate = TryGetTransition(_currState);

        if (candidate == null)
        {
            return;
        }
        
        ChangeToState(candidate);
    }

    public void Terminate()
    {
        _currState?.OnExit();
    }
    
    #endregion

    #region Internal Functions

    private void ChangeToState(State state)
    {
        if (_currState == state)
        {
            return;
        }

        _prevState = _currState;
        _currState = state;
        
        _prevState?.OnExit();
        _currState?.OnEnter();
    }

    private State? TryGetTransition(State state)
    {
        var result = _transitionsMap.TryGetValue(state, out var transitions);

        if (!result || transitions == null)
        {
            return null;
        }
        
        foreach (var transition in transitions)
        {
            if (transition.ShouldTransition())
            {
                return transition.Target;
            }
        }

        return null;
    }

    #endregion
}
