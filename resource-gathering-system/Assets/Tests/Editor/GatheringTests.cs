using NUnit.Framework;

public sealed class GatheringTests
{
    [Test]
    public void GatherThenDeliverMovesWoodToInventory()
    {
        var source = new ResourceSource(ResourceType.Wood, 5);
        var inventory = new ResourceInventory();
        var service = new GatheringService();
        int carried = 0;

        Assert.That(service.Gather(source, 5, ref carried), Is.EqualTo(5));
        Assert.That(service.Deliver(ResourceType.Wood, ref carried, inventory), Is.True);
        Assert.That(source.Remaining, Is.EqualTo(0));
        Assert.That(carried, Is.EqualTo(0));
        Assert.That(inventory.Get(ResourceType.Wood), Is.EqualTo(5));
    }

    [Test]
    public void EmptySourceAndInvalidDeliveryChangeNothing()
    {
        var source = new ResourceSource(ResourceType.Wood, 0);
        var inventory = new ResourceInventory();
        var service = new GatheringService();
        int carried = 0;

        Assert.That(service.Gather(source, 5, ref carried), Is.EqualTo(0));
        Assert.That(service.Deliver(ResourceType.Wood, ref carried, inventory), Is.False);
        Assert.That(inventory.Get(ResourceType.Wood), Is.EqualTo(0));
    }

    [Test]
    public void CollectorCannotGatherWhileAlreadyCarrying()
    {
        var source = new ResourceSource(ResourceType.Wood, 10);
        var service = new GatheringService();
        int carried = 0;

        Assert.That(service.Gather(source, 5, ref carried), Is.EqualTo(5));
        Assert.That(service.Gather(source, 5, ref carried), Is.EqualTo(0));
        Assert.That(source.Remaining, Is.EqualTo(5));
        Assert.That(carried, Is.EqualTo(5));
    }
}
