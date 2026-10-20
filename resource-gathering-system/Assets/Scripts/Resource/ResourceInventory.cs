using System.Collections.Generic;

public sealed class ResourceInventory
{
    private readonly Dictionary<ResourceType, int> amounts = new();

    public void Add(ResourceType type, int amount)
    {
        if (amount <= 0) return;
        amounts[type] = Get(type) + amount;
    }

    public int Get(ResourceType type)
    {
        return amounts.TryGetValue(type, out int amount) ? amount : 0;
    }

    public bool TrySpend(ResourceType type, int amount)
    {
        if (amount <= 0 || Get(type) < amount) return false;
        amounts[type] -= amount;
        return true;
    }
}
