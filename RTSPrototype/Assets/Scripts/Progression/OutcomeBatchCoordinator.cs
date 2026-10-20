using System.Collections.Generic;
using UnityEngine;

namespace RTSPrototype.Progression
{
    public enum OutcomeUpdateKind { ObjectivesComplete, DefenseAlive }

    public readonly struct OutcomeUpdate
    {
        public readonly OutcomeUpdateKind Kind;
        public readonly bool Value;

        public OutcomeUpdate(OutcomeUpdateKind kind, bool value)
        {
            Kind = kind;
            Value = value;
        }
    }

    public sealed class OutcomeBatchCoordinator : MonoBehaviour
    {
        [SerializeField] private GameOutcomeController outcomeController;
        private readonly List<OutcomeUpdate> pendingUpdates = new();

        public void PublishObjectivesComplete(bool value)
        {
            pendingUpdates.Add(new OutcomeUpdate(OutcomeUpdateKind.ObjectivesComplete, value));
        }

        public void PublishDefenseAlive(bool value)
        {
            pendingUpdates.Add(new OutcomeUpdate(OutcomeUpdateKind.DefenseAlive, value));
        }

        public void ProcessCurrentBatch()
        {
            OutcomeUpdate[] batch = pendingUpdates.ToArray();
            pendingUpdates.Clear();

            foreach (OutcomeUpdate update in batch)
            {
                if (update.Kind == OutcomeUpdateKind.ObjectivesComplete)
                    outcomeController.SetObjectivesComplete(update.Value);
                else
                    outcomeController.SetDefenseAlive(update.Value);
            }

            outcomeController.CommitState();
        }
    }
}
