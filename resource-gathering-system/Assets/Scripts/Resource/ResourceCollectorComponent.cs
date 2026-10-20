using UnityEngine;

public sealed class ResourceCollectorComponent : MonoBehaviour
{
    public bool CollectCommandActive { get; private set; }
    public int Carried { get; private set; }

    private ResourceSource source;
    private readonly GatheringService service = new();

    public void SetCollectCommand(bool active)
    {
        CollectCommandActive = active;
    }

    public void SetSource(ResourceSource value)
    {
        source = value;
    }

    public int Gather(int requested)
    {
        if (!CollectCommandActive) return 0;
        return service.Gather(source, requested, ref Carried);
    }

    public bool Deliver(ResourceType type, ResourceInventory inventory)
    {
        return service.Deliver(type, ref Carried, inventory);
    }
}
