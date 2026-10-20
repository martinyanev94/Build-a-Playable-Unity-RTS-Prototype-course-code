using UnityEngine;

namespace RTSPrototype
{
    public enum UnitCommandState
    {
        Idle,
        Moving
    }

    public class UnitComponent : MonoBehaviour
    {
        [SerializeField] private float _walkSpeed = 3f;
        [SerializeField] private float _arrivalDistance = 0.05f;

        public UnitCommandState CommandState { get; private set; } = UnitCommandState.Idle;
        public Vector3 CommandDestination { get; private set; }

        public void SetMoveDestination(Vector3 destination)
        {
            CommandDestination = destination;
            CommandState = UnitCommandState.Moving;
        }

        private void Update()
        {
            if (CommandState != UnitCommandState.Moving)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                CommandDestination,
                _walkSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, CommandDestination) <= _arrivalDistance)
            {
                transform.position = CommandDestination;
                CommandState = UnitCommandState.Idle;
            }
        }
    }
}
