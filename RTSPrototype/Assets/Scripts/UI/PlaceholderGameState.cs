using UnityEngine;

public class PlaceholderGameState : MonoBehaviour
{
    public int Gold { get; private set; } = 120;
    public int Wood { get; private set; } = 80;
    public int Food { get; private set; } = 45;
    public string SelectedUnitName { get; private set; } = "Scout";
    public int SelectedUnitHealth { get; private set; } = 75;

    public void SpendGold(int amount)
    {
        Gold = Mathf.Max(0, Gold - amount);
    }
}
