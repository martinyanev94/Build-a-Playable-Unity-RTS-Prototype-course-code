using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private float _borderSize = 24f;
    [SerializeField] private float _panSpeed = 12f;
    [SerializeField] private Vector2 _panLimit = new Vector2(35f, 25f);
    [SerializeField] private float _scrollSpeed = 8f;
    [SerializeField] private Vector2 _scrollLimit = new Vector2(5f, 20f);

    private Vector3 _initialPosition;
    private Camera _camera;

    private void Start()
    {
        _initialPosition = transform.position;
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        UpdatePan();
        UpdateZoom();
    }

    private void UpdatePan()
    {
        Vector3 position = transform.position;

        if (Input.mousePosition.y >= Screen.height - _borderSize)
            position.z += _panSpeed * Time.deltaTime;
        if (Input.mousePosition.y <= _borderSize)
            position.z -= _panSpeed * Time.deltaTime;
        if (Input.mousePosition.x >= Screen.width - _borderSize)
            position.x += _panSpeed * Time.deltaTime;
        if (Input.mousePosition.x <= _borderSize)
            position.x -= _panSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(
            position.x,
            -_panLimit.x + _initialPosition.x,
            _panLimit.x + _initialPosition.x);

        position.z = Mathf.Clamp(
            position.z,
            -_panLimit.y + _initialPosition.z,
            _panLimit.y + _initialPosition.z);

        transform.position = position;
    }

    private void UpdateZoom()
    {
        float scroll = Input.mouseScrollDelta.y;
        _camera.orthographicSize -= scroll * _scrollSpeed * Time.deltaTime;
        _camera.orthographicSize = Mathf.Clamp(
            _camera.orthographicSize,
            _scrollLimit.x,
            _scrollLimit.y);
    }
}
