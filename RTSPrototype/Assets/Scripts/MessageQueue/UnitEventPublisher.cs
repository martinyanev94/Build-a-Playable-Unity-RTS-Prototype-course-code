using UnityEngine;

public sealed class UnitEventPublisher : MonoBehaviour
{
    public void PublishSpawned(int unitId, string unitName)
    {
        MessageQueueManager.Instance.Publish(
            new UnitSpawnedMessage(unitId, unitName, transform.position));
    }

    public void PublishReleased(int unitId)
    {
        MessageQueueManager.Instance.Publish(
            new UnitReleasedMessage(unitId));
    }
}
