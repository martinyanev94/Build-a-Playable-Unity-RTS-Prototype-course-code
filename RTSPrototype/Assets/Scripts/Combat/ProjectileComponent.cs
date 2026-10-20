using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    private Vector3 _direction;
    private int _damage;
    private float _speed;
    private float _expiresAt;
    private bool _active;

    public void Setup(Vector3 position, Vector3 direction, int damage, float speed, float lifetime)
    {
        transform.SetPositionAndRotation(position, Quaternion.LookRotation(direction));
        _direction = direction.normalized;
        _damage = damage;
        _speed = speed;
        _expiresAt = Time.time + lifetime;
        _active = true;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!_active) return;
        transform.position += _direction * _speed * Time.deltaTime;
        if (Time.time >= _expiresAt) ReleaseToPool();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_active) return;
        CombatUnit target = other.GetComponentInParent<CombatUnit>();
        if (target == null || target.IsDead) return;
        target.TakeDamage(_damage);
        ReleaseToPool();
    }

    private void ReleaseToPool()
    {
        _active = false;
        _direction = Vector3.zero;
        _damage = 0;
        gameObject.SetActive(false);
    }
}
