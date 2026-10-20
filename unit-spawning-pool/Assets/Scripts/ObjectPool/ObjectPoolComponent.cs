using System.Collections.Generic;
using UnityEngine;

namespace Dragoncraft
{
    public class ObjectPoolComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _poolSize = 10;
        [SerializeField] private bool _allowCreation;
        private readonly List<GameObject> _gameObjects = new();

        private void Awake()
        {
            for (int i = 0; i < _poolSize; i++)
                _gameObjects.Add(CreateItem(false));
        }

        public GameObject GetItem(Vector3 position, Quaternion rotation)
        {
            foreach (GameObject item in _gameObjects)
            {
                if (item.activeSelf) continue;
                item.transform.SetPositionAndRotation(position, rotation);
                item.SetActive(true);
                return item;
            }

            if (!_allowCreation) return null;
            GameObject created = CreateItem(true);
            created.transform.SetPositionAndRotation(position, rotation);
            return created;
        }

        public void ReleaseItem(GameObject item)
        {
            if (item == null) return;
            item.SetActive(false);
        }

        private GameObject CreateItem(bool active)
        {
            GameObject item = Instantiate(_prefab, transform);
            item.SetActive(active);
            return item;
        }
    }
}
