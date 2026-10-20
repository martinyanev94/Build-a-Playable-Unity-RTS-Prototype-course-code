using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    public EnemyData Data { get; private set; }
    public int CurrentHealth { get; private set; }
    public bool IsDead => CurrentHealth <= 0;

    [SerializeField] private DamageFeedback damageFeedbackPrefab;
    [SerializeField] private Renderer modelRenderer;

    public void Initialize(EnemyData data)
    {
        if (data == null)
        {
            Debug.LogError("EnemyComponent requires EnemyData.", this);
            enabled = false;
            return;
        }

        Data = data;
        CurrentHealth = data.health;
    }

    public void TakeDamage(int amount)
    {
        if (Data == null || IsDead)
            return;

        int appliedDamage = Mathf.Max(0, amount - Data.defense);
        CurrentHealth = Mathf.Max(0, CurrentHealth - appliedDamage);
        ShowDamage(appliedDamage);
    }

    private void ShowDamage(int amount)
    {
        if (damageFeedbackPrefab == null || modelRenderer == null)
            return;

        Vector3 position = new Vector3(
            modelRenderer.bounds.center.x + Random.Range(-0.3f, 0.3f),
            modelRenderer.bounds.max.y,
            modelRenderer.bounds.center.z);

        DamageFeedback feedback = Instantiate(
            damageFeedbackPrefab,
            position,
            Quaternion.identity);
        feedback.Initialize(amount);
    }
}
