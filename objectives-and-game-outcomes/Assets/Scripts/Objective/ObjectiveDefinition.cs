using System;
using System.Collections.Generic;
using UnityEngine;

namespace RTSPrototype.Objectives
{
    public enum ObjectiveKind
    {
        Resource,
        Exploration,
        EnemyDefeat
    }

    [Serializable]
    public class ObjectiveEntry
    {
        public ObjectiveKind kind;
        public string label;
        public string type;
        [Min(1)] public int target = 1;
    }

    [CreateAssetMenu(menuName = "RTS Prototype/Objective Definition")]
    public sealed class ObjectiveDefinition : ScriptableObject
    {
        [TextArea] public string description;
        [Min(1)] public int timeInSeconds = 900;
        public List<ObjectiveEntry> entries = new();
    }
}
