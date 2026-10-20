using System.Collections.Generic;
using UnityEngine;

namespace RTSPrototype
{
    public class UnitSelectorComponent : MonoBehaviour
    {
        [SerializeField] private Camera _gameCamera;
        [SerializeField] private LayerMask _terrainMask;
        [SerializeField] private float _distanceBetweenUnits = 2f;
        [SerializeField] private UnitSelectorUI _selectorUI;

        public List<UnitComponent> SelectedUnits { get; } = new();

        private void Update()
        {
            HandleSelectionInput();

            if (Input.GetKeyUp(KeyCode.Mouse1) &&
                TryGetMousePosition(out Vector3 movePosition))
            {
                MoveSelectedUnits(movePosition);
            }
        }

        private void HandleSelectionInput()
        {
            // Existing click and drag-box selection logic remains here.
        }

        private bool TryGetMousePosition(out Vector3 position)
        {
            Ray ray = _gameCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 500f, _terrainMask))
            {
                position = hit.point;
                return true;
            }

            position = default;
            return false;
        }

        private void MoveSelectedUnits(Vector3 movePosition)
        {
            if (SelectedUnits.Count == 0)
            {
                return;
            }

            int rowWidth = Mathf.Max(1, Mathf.CeilToInt(Mathf.Sqrt(SelectedUnits.Count)));

            for (int i = 0; i < SelectedUnits.Count; i++)
            {
                int row = i / rowWidth;
                int column = i % rowWidth;
                Vector3 slot = movePosition + new Vector3(
                    (column - (rowWidth - 1) * 0.5f) * _distanceBetweenUnits,
                    0f,
                    row * _distanceBetweenUnits);

                SelectedUnits[i].SetMoveDestination(slot);
            }

            _selectorUI.SetCommandState($"Moving {SelectedUnits.Count} units");
        }
    }
}
