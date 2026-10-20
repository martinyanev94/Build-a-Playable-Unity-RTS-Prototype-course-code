using System.Collections;
using UnityEngine;

public interface ITrainingWallet
{
    bool TrySpend(int gold, int food);
}

public interface ITrainingSpawner
{
    void Spawn(GameObject unitPrefab, Vector3 position);
}

public sealed class TrainingBuilding : MonoBehaviour
{
    [SerializeField] private TrainingRecipe recipe;
    [SerializeField] private MonoBehaviour walletSource;
    [SerializeField] private MonoBehaviour spawnerSource;
    [SerializeField] private Transform spawnPoint;

    private ITrainingWallet wallet;
    private ITrainingSpawner spawner;
    private bool training;

    private void Awake()
    {
        wallet = walletSource as ITrainingWallet;
        spawner = spawnerSource as ITrainingSpawner;
    }

    public bool IsTraining => training;

    public bool TryStartTraining()
    {
        if (training || recipe == null || recipe.unitPrefab == null || spawnPoint == null)
            return false;
        if (wallet == null || spawner == null)
            return false;
        if (!wallet.TrySpend(recipe.goldCost, recipe.foodCost))
            return false;

        training = true;
        StartCoroutine(CompleteTraining());
        return true;
    }

    private IEnumerator CompleteTraining()
    {
        yield return new WaitForSeconds(recipe.duration);
        spawner.Spawn(recipe.unitPrefab, spawnPoint.position);
        training = false;
    }
}
