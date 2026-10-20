using System;
using System.Collections.Generic;
using UnityEngine;

namespace RTSPrototype.Objectives
{
    public sealed class ObjectiveTracker : MonoBehaviour
    {
        [SerializeField] private ObjectiveDefinition definition;
        private readonly List<int> progress = new();

        public event Action ProgressChanged;
        public ObjectiveDefinition Definition => definition;
        public IReadOnlyList<int> Progress => progress;

        private void Awake()
        {
            progress.Clear();
            if (definition == null) return;
            foreach (var entry in definition.entries)
                progress.Add(0);
        }

        public void ReportProgress(ObjectiveKind kind, string type, int amount)
        {
            if (definition == null || amount <= 0) return;

            for (int i = 0; i < definition.entries.Count; i++)
            {
                var entry = definition.entries[i];
                if (entry.kind != kind || entry.type != type) continue;
                progress[i] = Mathf.Min(entry.target, progress[i] + amount);
                ProgressChanged?.Invoke();
            }
        }

        public bool IsComplete()
        {
            if (definition == null || progress.Count != definition.entries.Count)
                return false;

            for (int i = 0; i < definition.entries.Count; i++)
                if (progress[i] < definition.entries[i].target) return false;

            return true;
        }
    }
}
