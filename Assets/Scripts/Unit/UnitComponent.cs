using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    [SerializeField] private string _unitId;
    [SerializeField] private string _unitType = "Warrior";
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _health = 100;
    [SerializeField] private bool _isActiveUnit = true;

    public string UnitId => _unitId;
    public string UnitType => _unitType;
    public int CurrentHealth => _health;
    public int MaximumHealth => _maxHealth;
    public bool IsActiveUnit => _isActiveUnit;

    public void Initialize(string unitId, string unitType, int maximumHealth)
    {
        _unitId = unitId;
        _unitType = unitType;
        _maxHealth = Mathf.Max(1, maximumHealth);
        _health = _maxHealth;
        _isActiveUnit = true;
    }

    public void ApplyDamage(int damage)
    {
        if (!_isActiveUnit)
        {
            return;
        }

        _health = Mathf.Max(0, _health - Mathf.Max(0, damage));
        if (_health == 0)
        {
            _isActiveUnit = false;
        }
    }

    public void ResetRuntimeState()
    {
        _health = _maxHealth;
        _isActiveUnit = true;
    }

    public void DebugRestoreHealth()
    {
        _health = _maxHealth;
        _isActiveUnit = true;
    }
}
