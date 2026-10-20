using UnityEngine;

namespace RTSPrototype
{
    public class LevelComponent : MonoBehaviour
    {
        [SerializeField] private LevelData levelData;
        [SerializeField] private Transform generatedRoot;

        [ContextMenu("Generate Map")]
        public void GenerateMap()
        {
            ClearGenerated();
            if (!ValidateData()) return;

            foreach (LevelPlacement placement in levelData.Placements)
            {
                GeneratePlacement(placement);
            }
        }

        private void GeneratePlacement(LevelPlacement placement)
        {
            GameObject prefab = levelData.Configuration.GetPrefab(placement.Type);
            if (prefab == null)
            {
                Debug.LogError($"No Prefab configured for {placement.Type}", this);
                return;
            }

            GameObject instance = Instantiate(
                prefab, placement.Position, placement.Rotation, generatedRoot);
            instance.name = $"{placement.Type}_Generated";
        }

        private void ClearGenerated()
        {
            if (generatedRoot == null) return;

            for (int i = generatedRoot.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(generatedRoot.GetChild(i).gameObject);
            }
        }

        private bool ValidateData()
        {
            if (levelData == null || generatedRoot == null)
            {
                Debug.LogError("Assign LevelData and Generated Root.", this);
                return false;
            }

            if (levelData.Configuration == null)
            {
                Debug.LogError("LevelData has no configuration.", this);
                return false;
            }

            if (!levelData.Configuration.ValidateReferences()) return false;

            foreach (LevelPlacement placement in levelData.Placements)
            {
                if (levelData.Configuration.GetPrefab(placement.Type) == null)
                {
                    Debug.LogError($"No Prefab configured for {placement.Type}", this);
                    return false;
                }
            }

            return true;
        }
    }
}
