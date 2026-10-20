using System.Collections.Generic;

namespace RTSPrototype.Combat
{
    public readonly struct CombatStats
    {
        public CombatStats(int health, int attack)
        {
            Health = health;
            Attack = attack;
        }

        public int Health { get; }
        public int Attack { get; }
    }

    public sealed class BattleResult
    {
        public bool UnitWon { get; init; }
        public int EnemiesDefeated { get; init; }
    }

    public static class BattleSimulator
    {
        public static BattleResult Simulate(
            CombatStats unit,
            IReadOnlyList<CombatStats> enemies)
        {
            int unitHealth = unit.Health;
            int defeated = 0;

            foreach (CombatStats enemy in enemies)
            {
                if (unitHealth <= 0)
                    break;

                unitHealth -= enemy.Attack;
                if (unitHealth > 0 && unit.Attack >= enemy.Health)
                    defeated++;
            }

            return new BattleResult
            {
                UnitWon = unitHealth > 0 && defeated == enemies.Count,
                EnemiesDefeated = defeated
            };
        }
    }
}
