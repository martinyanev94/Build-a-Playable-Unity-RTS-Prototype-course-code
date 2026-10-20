namespace RTSPrototype.Combat
{
    public readonly record struct CombatStats(
        int MaxHealth, int Attack, int Defense);

    public readonly record struct BattleResult(
        string Winner, int Rounds, int UnitHealth, bool EnemyDefeated);

    public static class BattleSimulator
    {
        public static BattleResult Simulate(CombatStats unit, CombatStats enemy)
        {
            var unitHealth = unit.MaxHealth;
            var enemyHealth = enemy.MaxHealth;
            var rounds = 0;

            while (unitHealth > 0 && enemyHealth > 0)
            {
                rounds++;
                enemyHealth -= System.Math.Max(0, unit.Attack - enemy.Defense);

                if (enemyHealth > 0)
                {
                    unitHealth -= System.Math.Max(0, enemy.Attack - unit.Defense);
                }
            }

            return new BattleResult(
                enemyHealth <= 0 ? "Unit" : "Enemy",
                rounds,
                System.Math.Max(0, unitHealth),
                enemyHealth <= 0);
        }
    }
}
