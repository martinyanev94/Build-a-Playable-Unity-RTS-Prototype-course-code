using UnityEngine;

public sealed class ResourceCollectionComponent : MonoBehaviour
{
    [SerializeField] private ResourceData resource;
    [SerializeField] private int amount = 5;

    public ResourceSource CreateSource()
    {
        return resource == null ? null : new ResourceSource(resource.Type, amount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var collector = collision.gameObject.GetComponent<ResourceCollectorComponent>();
        if (collector != null && collector.CollectCommandActive)
            collector.SetSource(CreateSource());
    }
}
