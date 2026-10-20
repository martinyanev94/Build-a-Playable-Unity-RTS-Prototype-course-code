using UnityEngine;

namespace RTSPrototype.Progression
{
    public sealed class DefenseForceState : MonoBehaviour
    {
        [SerializeField] private OutcomeBatchCoordinator outcomeCoordinator;
        [SerializeField] private int aliveDefenders = 1;

        public void DefenderDefeated()
        {
            aliveDefenders--;
            if (aliveDefenders == 0)
                outcomeCoordinator.PublishDefenseAlive(false);
        }
    }
}
