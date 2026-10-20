using UnityEngine;

public sealed class TrainingWallet : MonoBehaviour, ITrainingWallet
{
    [SerializeField] private int gold;
    [SerializeField] private int food;

    public int Gold => gold;
    public int Food => food;

    public bool TrySpend(int goldCost, int foodCost)
    {
        if (goldCost < 0 || foodCost < 0 || gold < goldCost || food < foodCost)
            return false;

        gold -= goldCost;
        food -= foodCost;
        return true;
    }
}
