using UnityEngine;

[CreateAssetMenu(menuName = "RTS/Unit Data")]
public class UnitData : ScriptableObject
{
    [Min(0)] public int Attack = 10;
    [Min(0)] public int Defense = 5;
    [Min(0.1f)] public float AttackRange = 1.5f;
    [Min(0.01f)] public float AttackCooldown = 1f;
    public GameObject ProjectilePrefab;
    [Min(0.01f)] public float ProjectileSpeed = 12f;
    [Min(0.01f)] public float ProjectileLifetime = 3f;
}
