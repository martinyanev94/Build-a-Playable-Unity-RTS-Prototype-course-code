using System;
using UnityEngine;

[Serializable]
public class EnemySpawnEntry
{
    public EnemyData data;
    public EnemyComponent prefab;
    public Transform spawnPoint;
    [Min(1)] public int count = 1;
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnEntry[] entries;

    private void Start()
    {
        foreach (EnemySpawnEntry entry in entries)
        {
            if (entry.data == null || entry.prefab == null || entry.spawnPoint == null)
            {
                Debug.LogError("Enemy spawn entry has a missing reference.", this);
                continue;
            }

            for (int i = 0; i < entry.count; i++)
            {
                EnemyComponent enemy = Instantiate(
                    entry.prefab,
                    entry.spawnPoint.position,
                    entry.spawnPoint.rotation);
                enemy.Initialize(entry.data);
            }
        }
    }
}
