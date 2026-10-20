using TMPro;
using UnityEngine;

namespace RTSPrototype.Objectives
{
    public sealed class ObjectiveProgressView : MonoBehaviour
    {
        [SerializeField] private ObjectiveTracker tracker;
        [SerializeField] private TMP_Text text;

        private void OnEnable()
        {
            if (tracker != null) tracker.ProgressChanged += Refresh;
            Refresh();
        }

        private void OnDisable()
        {
            if (tracker != null) tracker.ProgressChanged -= Refresh;
        }

        private void Refresh()
        {
            if (tracker == null || tracker.Definition == null || text == null) return;

            var lines = new System.Text.StringBuilder();
            for (int i = 0; i < tracker.Definition.entries.Count; i++)
            {
                var entry = tracker.Definition.entries[i];
                lines.Append(entry.label).Append(": ")
                    .Append(tracker.Progress[i]).Append(" / ")
                    .Append(entry.target).AppendLine();
            }

            text.text = lines.ToString();
        }
    }
}
