using NUnit.Framework;
using RTSPrototype.Combat;

public sealed class BattleSimulationTests
{
    [Test]
    public void WarriorDefeatsConfiguredOrcInThreeRounds()
    {
        var warrior = new CombatStats(50, 12, 0);
        var orc = new CombatStats(30, 7, 2);

        var result = BattleSimulator.Simulate(warrior, orc);

        Assert.That(result.Winner, Is.EqualTo("Unit"));
        Assert.That(result.Rounds, Is.EqualTo(3));
        Assert.That(result.UnitHealth, Is.EqualTo(29));
        Assert.That(result.EnemyDefeated, Is.True);
    }

    [Test]
    public void WarriorDefeatsOrcWithSixHealth()
    {
        var warrior = new CombatStats(20, 12, 0);
        var orc = new CombatStats(30, 7, 2);

        var result = BattleSimulator.Simulate(warrior, orc);

        Assert.That(result.Winner, Is.EqualTo("Unit"));
        Assert.That(result.Rounds, Is.EqualTo(3));
        Assert.That(result.UnitHealth, Is.EqualTo(6));
        Assert.That(result.EnemyDefeated, Is.True);
    }
}
