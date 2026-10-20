using System;
using System.Collections.Generic;
using UnityEngine;

namespace RTSPrototype.Configuration
{
    [Serializable]
    public class LevelPlacement
    {
        public LevelItemType type;
        public Vector3 position;
        public Vector3 rotationEuler;
    }

    [CreateAssetMenu(menuName = "RTS/Level Data")]
    public class LevelData : ScriptableObject
    {
        public LevelConfiguration configuration;
        public List<LevelPlacement> placements = new List<LevelPlacement>();
    }
}
