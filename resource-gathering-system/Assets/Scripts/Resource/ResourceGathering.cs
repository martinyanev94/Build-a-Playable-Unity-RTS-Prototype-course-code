using UnityEngine;

public sealed class ResourceSource
{
    public ResourceSource(ResourceType type, int amount)
    {
        Type = type;
        Remaining = Mathf.Max(0, amount);
    }

    public ResourceType Type { get; }
    public int Remaining { get; private set; }

    public int Take(int requested)
    {
        if (requested <= 0) return 0;
        int collected = Mathf.Min(requested, Remaining);
        Remaining -= collected;
        return collected;
    }
}

public sealed class GatheringService
{
    public int Gather(ResourceSource source, int requested, ref int carried)
    {
        if (source == null || requested <= 0 || carried != 0) return 0;
        int amount = source.Take(requested);
        carried += amount;
        return amount;
    }

    public bool Deliver(ResourceType type, ref int carried, ResourceInventory inventory)
    {
        if (inventory == null || carried <= 0) return false;
        inventory.Add(type, carried);
        carried = 0;
        return true;
    }
}
