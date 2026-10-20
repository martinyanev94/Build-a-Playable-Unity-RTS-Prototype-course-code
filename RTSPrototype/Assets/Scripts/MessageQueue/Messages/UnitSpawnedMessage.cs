using UnityEngine;

public readonly struct UnitSpawnedMessage
{
    public readonly int UnitId;
    public readonly string UnitName;
    public readonly Vector3 Position;

    public UnitSpawnedMessage(int unitId, string unitName, Vector3 position)
    {
        UnitId = unitId;
        UnitName = unitName;
        Position = position;
    }
}
