using UnityEngine;

public sealed class UnitSelectionVisual : MonoBehaviour
{
    [SerializeField] private Color _selectedColor = new Color(0.45f, 0.8f, 1f, 1f);
    [SerializeField] private Color _defaultColor = Color.white;

    private Renderer[] _renderers;
    private MaterialPropertyBlock _properties;

    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
    private static readonly int ColorProperty = Shader.PropertyToID("_Color");

    private void Awake()
    {
        _renderers = GetComponentsInChildren<Renderer>(true);
        _properties = new MaterialPropertyBlock();
    }

    public void SetSelected(bool selected)
    {
        Color color = selected ? _selectedColor : _defaultColor;
        foreach (Renderer renderer in _renderers)
        {
            renderer.GetPropertyBlock(_properties);
            _properties.SetColor(BaseColor, color);
            _properties.SetColor(ColorProperty, color);
            renderer.SetPropertyBlock(_properties);
        }
    }
}
