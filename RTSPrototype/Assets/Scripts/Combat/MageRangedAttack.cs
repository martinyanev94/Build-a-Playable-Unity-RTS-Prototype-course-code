using UnityEngine;

public class MageRangedAttack : MonoBehaviour
{
    [SerializeField] private UnitData _unitData;
    [SerializeField] private ProjectileComponent _projectilePrefab;
    [SerializeField] private Transform _target;

    private float _cooldownRemaining;

    private void Update()
    {
        if (_target == null || _target.GetComponent<CombatUnit>().IsDead) return;
        _cooldownRemaining -= Time.deltaTime;
        Vector3 offset = _target.position - transform.position;
        offset.y = 0f;
        if (offset.magnitude > _unitData.AttackRange || _cooldownRemaining > 0f) return;
        Fire(offset.normalized);
        _cooldownRemaining = _unitData.AttackCooldown;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Fire(Vector3 direction)
    {
        ProjectileComponent projectile = Instantiate(
            _projectilePrefab, transform.position, Quaternion.identity);
        projectile.Setup(
            transform.position, direction, _unitData.Attack,
            _unitData.ProjectileSpeed, _unitData.ProjectileLifetime);
    }
}
