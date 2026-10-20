# Army selection milestone

This Unity milestone adds single-click and drag-box selection to the existing RTS project.

## Scene setup

1. Add `UnitSelectorComponent` to the `UnitSelector` child under `LevelManager`.
2. Assign the gameplay camera and the `UnitSelectorUI` reference.
3. Add `UnitSelectorUI` to the UI scene.
4. Assign its translucent `Image` RectTransform and Canvas.
5. Add `UnitSelectionVisual` to each controllable unit prefab.
6. Ensure each unit has a collider and a live `UnitComponent` on its root or a parent of the collider.

The translucent selection Image should be disabled at startup. Use a green color with transparency so the map remains visible during a drag.

The selector uses the existing `UnitComponent` runtime type. It exposes the current set through `SelectedUnits`, which the movement lesson can consume.
