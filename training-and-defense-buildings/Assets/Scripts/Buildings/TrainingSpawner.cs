using UnityEngine;

public sealed class TrainingSpawner : MonoBehaviour, ITrainingSpawner
{
    public void Spawn(GameObject unitPrefab, Vector3 position)
    {
        if (unitPrefab == null)
            return;

        Instantiate(unitPrefab, position, Quaternion.identity);
    }
}
