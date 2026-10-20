using UnityEngine;

namespace Dragoncraft
{
    public class UnitComponent : MonoBehaviour
    {
        public string ID;
        public UnitType Type;
        public int Level;
        public float LevelMultiplier;
        public float Health;
        public float Attack;
        public float Defense;
        public float WalkSpeed;
        public float AttackSpeed;

        public void Initialize(UnitData data, string id)
        {
            ID = id;
            Type = data.Type;
            Level = data.Level;
            LevelMultiplier = data.LevelMultiplier;
            Health = data.Health;
            Attack = data.Attack;
            Defense = data.Defense;
            WalkSpeed = data.WalkSpeed;
            AttackSpeed = data.AttackSpeed;
        }

        public void ResetRuntimeState()
        {
            ID = string.Empty;
            Health = 0f;
        }
    }
}
