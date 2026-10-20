using System;
using UnityEngine;

namespace RTSPrototype.Configuration
{
    [Serializable]
    public class LevelItem
    {
        [SerializeField] private LevelItemType type;
        [SerializeField] private GameObject prefab;

        public LevelItemType Type => type;
        public GameObject Prefab => prefab;
    }
}
