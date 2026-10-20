using UnityEngine;

[CreateAssetMenu(menuName = "RTS/Training Recipe")]
public sealed class TrainingRecipe : ScriptableObject
{
    public string unitId;
    public GameObject unitPrefab;
    public int goldCost = 60;
    public int foodCost = 40;
    public float duration = 3f;
}
