using System.Collections.Generic;
using NUnit.Framework;
using RTSPrototype.Combat;

namespace RTSPrototype.Tests
{
    public sealed class BattleSimulationTests
    {
        private static readonly object[] BoundaryBattles =
        {
            new object[]
            {
                "Level 1 warrior versus one orc",
                new CombatStats(100, 25),
                new List<CombatStats> { new CombatStats(40, 50) },
                true
            },
            new object[]
            {
                "Level 1 warrior versus two orcs",
                new CombatStats(100, 25),
                new List<CombatStats>
                {
                    new CombatStats(40, 50),
                    new CombatStats(40, 50)
                },
                false
            },
            new object[]
            {
                "Level 2 warrior versus two orcs",
                new CombatStats(140, 35),
                new List<CombatStats>
                {
                    new CombatStats(40, 50),
                    new CombatStats(40, 50)
                },
                true
            }
        };

        [TestCaseSource(nameof(BoundaryBattles))]
        public void Battle_has_expected_outcome(
            string scenario,
            CombatStats unit,
            List<CombatStats> enemies,
            bool expectedWin)
        {
            BattleResult result = BattleSimulator.Simulate(unit, enemies);

            Assert.That(result.UnitWon, Is.EqualTo(expectedWin), scenario);
        }

        [Test]
        public void Defeated_unit_does_not_defeat_remaining_enemies()
        {
            CombatStats unit = new CombatStats(30, 25);
            var enemies = new List<CombatStats>
            {
                new CombatStats(40, 40),
                new CombatStats(40, 1)
            };

            BattleResult result = BattleSimulator.Simulate(unit, enemies);

            Assert.That(result.UnitWon, Is.False);
            Assert.That(result.EnemiesDefeated, Is.EqualTo(0));
        }
    }
}
