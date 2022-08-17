using System.Numerics;

namespace DynamisAI.Perceptions;

public class Stimulus
{
    public uint layer;
    public string? tag;
    public object? source;
    public Vector3 position;
    public Vector3 direction;
    public float radius;
    public float duration;
}