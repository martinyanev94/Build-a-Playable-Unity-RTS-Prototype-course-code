using UnityEngine;

[CreateAssetMenu(menuName = "RTS/New Resource")]
public sealed class ResourceData : ScriptableObject
{
    public ResourceType Type;
    public int ProductionPerSecond = 1;
    public int ProductionLevel = 1;
}
