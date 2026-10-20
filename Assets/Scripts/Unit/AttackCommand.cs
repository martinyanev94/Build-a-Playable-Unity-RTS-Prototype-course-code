using UnityEngine;

public class AttackCommand : MonoBehaviour
{
    [SerializeField] private CombatUnit selectedAttacker;
    [SerializeField] private CombatUnit selectedEnemy;

    public void AttackSelected()
    {
        if (selectedAttacker == null || selectedEnemy == null)
            return;

        selectedAttacker.SetTarget(selectedEnemy);
    }
}
