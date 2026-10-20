using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class UnitHudConsumer : MonoBehaviour
{
    [SerializeField] private Text activeUnitsText;
    private readonly HashSet<int> activeUnitIds = new();

    private void OnEnable()
    {
        MessageQueueManager.Instance.Subscribe<UnitSpawnedMessage>(OnSpawned);
        MessageQueueManager.Instance.Subscribe<UnitReleasedMessage>(OnReleased);
        RefreshText();
    }

    private void OnDisable()
    {
        MessageQueueManager.Instance.Unsubscribe<UnitSpawnedMessage>(OnSpawned);
        MessageQueueManager.Instance.Unsubscribe<UnitReleasedMessage>(OnReleased);
    }

    private void OnSpawned(UnitSpawnedMessage message)
    {
        activeUnitIds.Add(message.UnitId);
        RefreshText();
    }

    private void OnReleased(UnitReleasedMessage message)
    {
        activeUnitIds.Remove(message.UnitId);
        RefreshText();
    }

    private void RefreshText()
    {
        if (activeUnitsText != null)
            activeUnitsText.text = $"Units: {activeUnitIds.Count}";
    }
}
