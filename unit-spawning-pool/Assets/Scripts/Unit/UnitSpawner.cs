using UnityEngine;

namespace Dragoncraft
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private UnitData _warriorData;
        [SerializeField] private UnitData _mageData;
        [SerializeField] private ObjectPoolComponent _warriorPool;
        [SerializeField] private ObjectPoolComponent _magePool;
        [SerializeField] private Transform _warriorSpawn;
        [SerializeField] private Transform _mageSpawn;
        private int _nextUnitId = 1;

        public UnitComponent Spawn(UnitData data, Transform spawnPoint, ObjectPoolComponent pool)
        {
            if (data == null || spawnPoint == null || pool == null) return null;
            GameObject instance = pool.GetItem(spawnPoint.position, spawnPoint.rotation);
            if (instance == null) return null;

            UnitComponent unit = instance.GetComponent<UnitComponent>();
            if (unit == null)
            {
                pool.ReleaseItem(instance);
                return null;
            }

            unit.Initialize(data, $"U-{_nextUnitId++}");
            return unit;
        }

        public UnitComponent SpawnWarrior()
        {
            return Spawn(_warriorData, _warriorSpawn, _warriorPool);
        }

        public UnitComponent SpawnMage()
        {
            return Spawn(_mageData, _mageSpawn, _magePool);
        }

        public void Release(UnitComponent unit, ObjectPoolComponent pool)
        {
            if (unit == null || pool == null) return;
            unit.ResetRuntimeState();
            pool.ReleaseItem(unit.gameObject);
        }
    }
}
