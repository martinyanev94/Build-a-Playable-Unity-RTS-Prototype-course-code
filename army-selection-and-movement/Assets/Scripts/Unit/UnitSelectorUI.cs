using UnityEngine;

public sealed class UnitSelectorUI : MonoBehaviour
{
    [SerializeField] private RectTransform _box;
    [SerializeField] private Canvas _canvas;

    public void Show(Vector2 start)
    {
        _box.gameObject.SetActive(true);
        UpdateBox(start, start);
    }

    public void Hide()
    {
        _box.gameObject.SetActive(false);
    }

    public void UpdateBox(Vector2 start, Vector2 end)
    {
        RectTransform canvasRect = _canvas.transform as RectTransform;
        Camera eventCamera = _canvas.renderMode == RenderMode.ScreenSpaceOverlay
            ? null
            : _canvas.worldCamera;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect, start, eventCamera, out Vector2 first);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect, end, eventCamera, out Vector2 second);

        _box.anchoredPosition = (first + second) * 0.5f;
        _box.sizeDelta = new Vector2(
            Mathf.Abs(second.x - first.x),
            Mathf.Abs(second.y - first.y));
    }
}
