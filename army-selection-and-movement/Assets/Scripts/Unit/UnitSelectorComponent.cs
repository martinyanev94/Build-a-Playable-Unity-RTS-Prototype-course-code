using System.Collections.Generic;
using UnityEngine;

public sealed class UnitSelectorComponent : MonoBehaviour
{
    [SerializeField] private Camera _worldCamera;
    [SerializeField] private UnitSelectorUI _selectionUI;
    [SerializeField] private float _dragThreshold = 10f;

    private readonly List<UnitComponent> _selectedUnits = new();
    private Vector2 _dragStart;
    private bool _dragging;

    public IReadOnlyList<UnitComponent> SelectedUnits => _selectedUnits;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            BeginSelection();

        if (_dragging)
            UpdateSelectionBox();

        if (Input.GetMouseButtonUp(0))
            EndSelection();
    }

    private void BeginSelection()
    {
        _dragStart = Input.mousePosition;
        _dragging = true;
        _selectionUI.Show(_dragStart);
    }

    private void UpdateSelectionBox()
    {
        _selectionUI.UpdateBox(_dragStart, Input.mousePosition);
    }

    private void EndSelection()
    {
        Vector2 end = Input.mousePosition;
        _selectionUI.Hide();
        _dragging = false;

        if (Vector2.Distance(_dragStart, end) < _dragThreshold)
        {
            UnitComponent unit = TryGetUnitUnderCursor();
            SetSelection(unit == null
                ? new List<UnitComponent>()
                : new List<UnitComponent> { unit });
            return;
        }

        Rect box = MakeScreenRect(_dragStart, end);
        var matches = new List<UnitComponent>();

        foreach (UnitComponent unit in FindObjectsOfType<UnitComponent>())
        {
            Vector3 screen = _worldCamera.WorldToScreenPoint(unit.transform.position);
            if (screen.z > 0f && box.Contains(screen))
                matches.Add(unit);
        }

        SetSelection(matches);
    }

    private UnitComponent TryGetUnitUnderCursor()
    {
        Ray ray = _worldCamera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit hit)
            ? hit.collider.GetComponentInParent<UnitComponent>()
            : null;
    }

    private void SetSelection(List<UnitComponent> units)
    {
        foreach (UnitComponent unit in _selectedUnits)
            unit.GetComponent<UnitSelectionVisual>()?.SetSelected(false);

        _selectedUnits.Clear();
        _selectedUnits.AddRange(units);

        foreach (UnitComponent unit in _selectedUnits)
            unit.GetComponent<UnitSelectionVisual>()?.SetSelected(true);
    }

    private static Rect MakeScreenRect(Vector2 first, Vector2 second)
    {
        Vector2 min = Vector2.Min(first, second);
        Vector2 max = Vector2.Max(first, second);
        return Rect.MinMaxRect(min.x, min.y, max.x, max.y);
    }
}
