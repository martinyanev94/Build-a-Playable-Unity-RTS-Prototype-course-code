using UnityEngine;

public class CombatUnit : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float attack = 3f;
    [SerializeField] private float defense = 1f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 1.5f;

    private float health;
    private float cooldownTimer;
    private CombatUnit target;

    public bool IsDead { get; private set; }
    public float Health => health;
    public float MaxHealth => maxHealth;

    private void Awake()
    {
        health = maxHealth;
    }

    public void SetTarget(CombatUnit newTarget)
    {
        target = newTarget == this ? null : newTarget;
    }

    private void Update()
    {
        if (IsDead || target == null || target.IsDead)
            return;

        cooldownTimer -= Time.deltaTime;
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > attackRange || cooldownTimer > 0f)
            return;

        AttackTarget();
        cooldownTimer = attackCooldown;
    }

    private void AttackTarget()
    {
        bool targetDied = target.TakeDamage(attack);
        if (targetDied)
            target = null;
    }

    public bool TakeDamage(float incomingAttack)
    {
        if (IsDead)
            return true;

        float damage = Mathf.Max(incomingAttack - defense, 0f);
        health -= damage;
        if (health > 0f)
            return false;

        IsDead = true;
        health = 0f;
        return true;
    }
}
