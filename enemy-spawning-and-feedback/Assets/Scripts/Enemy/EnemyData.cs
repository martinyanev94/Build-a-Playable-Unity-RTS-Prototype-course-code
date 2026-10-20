using UnityEngine;

[CreateAssetMenu(menuName = "RTS/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int health = 100;
    public int attack = 10;
    public int defense = 2;
    public float walkSpeed = 2f;
    public float attackSpeed = 1f;
    public float attackRange = 1.5f;
    public float colliderSize = 1f;
}
