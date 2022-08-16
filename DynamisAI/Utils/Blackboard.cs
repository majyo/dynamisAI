namespace DynamisAI.Utils;

public class Blackboard
{
    private Dictionary<string, bool> _booleans = new();
    private Dictionary<string, int> _integers = new();
    private Dictionary<string, float> _floats = new();
    private Dictionary<string, object> _objects = new();

    public void SetBool(string key, bool value)
    {
        if (!_booleans.ContainsKey(key))
        {
            _booleans.Add(key, value);
        }
        
        _booleans[key] = value;
    }
    
    public void RemoveBool(string key)
    {
        _booleans.Remove(key);
    }
    
    public void SetInt(string key, int value)
    {
        if (!_integers.ContainsKey(key))
        {
            _integers.Add(key, value);
        }
        
        _integers[key] = value;
    }
    
    public void RemoveInt(string key)
    {
        _integers.Remove(key);
    }
    
    public void SetFloat(string key, float value)
    {
        if (!_floats.ContainsKey(key))
        {
            _floats.Add(key, value);
        }
        
        _floats[key] = value;
    }
    
    public void RemoveFloat(string key)
    {
        _floats.Remove(key);
    }
    
    public void SetObject(string key, object value)
    {
        if (!_objects.ContainsKey(key))
        {
            _objects.Add(key, value);
        }
        
        _objects[key] = value;
    }
    
    public void RemoveObject(string key)
    {
        _objects.Remove(key);
    }
}
