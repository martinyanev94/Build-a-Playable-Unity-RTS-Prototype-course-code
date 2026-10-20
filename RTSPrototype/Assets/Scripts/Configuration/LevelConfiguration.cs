using System.Collections.Generic;
using UnityEngine;

namespace RTSPrototype.Configuration
{
    [CreateAssetMenu(menuName = "RTS/Level Configuration")]
    public class LevelConfiguration : ScriptableObject
    {
        [SerializeField] private Vector2 mapSize = new Vector2(40f, 40f);
        [SerializeField] private List<LevelItem> levelItems = new List<LevelItem>();

        public Vector2 MapSize => mapSize;
        public IReadOnlyList<LevelItem> LevelItems => levelItems;
    }
}
