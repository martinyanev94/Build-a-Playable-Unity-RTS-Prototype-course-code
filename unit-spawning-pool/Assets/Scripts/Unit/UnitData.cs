using UnityEngine;

namespace Dragoncraft
{
    public enum UnitType
    {
        Warrior,
        Mage
    }

    [CreateAssetMenu(menuName = "Dragoncraft/Unit Data")]
    public class UnitData : ScriptableObject
    {
        public UnitType Type;
        public int Level = 1;
        public float LevelMultiplier = 1f;
        public float Health = 100f;
        public float Attack = 10f;
        public float Defense = 5f;
        public float WalkSpeed = 3.5f;
        public float AttackSpeed = 1f;
        public GameObject Prefab;
    }
}
