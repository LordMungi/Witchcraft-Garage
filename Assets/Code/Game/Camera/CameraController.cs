using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform leftCameraLimit;
    [SerializeField] private Transform rightCameraLimit;
    [Space]
    [SerializeField] private float panSpeed = 20;

    [Header("Listener Events")]
    [SerializeField] private EventChannel onLeftTriggerEnterUI;
    [SerializeField] private EventChannel onLeftTriggerExitUI;
    [SerializeField] private EventChannel onRightTriggerEnterUI;
    [SerializeField] private EventChannel onRightTriggerExitUI;

    private Camera _camera;

    private float _leftCameraLimitPosition;
    private float _rightCameraLimitPosition;

    private bool _isMovingLeft = false;
    private bool _isMovingRight = false;

    private void Start()
    {
        _camera = GetComponent<Camera>();

        float aspect = _camera.aspect > 16f / 9f ? 16f / 9f : _camera.aspect;
        float cameraWidth = _camera.orthographicSize * aspect;

        _leftCameraLimitPosition = leftCameraLimit.position.x + cameraWidth;
        _rightCameraLimitPosition = rightCameraLimit.position.x - cameraWidth;
    }
    private void OnEnable()
    {
        onLeftTriggerEnterUI.OnEventTriggered += HoverLeft;
        onLeftTriggerExitUI.OnEventTriggered += StopHover;
        onRightTriggerEnterUI.OnEventTriggered += HoverRight;
        onRightTriggerExitUI.OnEventTriggered += StopHover;
    }

    private void OnDisable()
    {
        onLeftTriggerEnterUI.OnEventTriggered -= HoverLeft;
        onLeftTriggerExitUI.OnEventTriggered -= StopHover;
        onRightTriggerEnterUI.OnEventTriggered -= HoverRight;
        onRightTriggerExitUI.OnEventTriggered -= StopHover;
    }

    void Update()
    {
        if (_isMovingLeft)
        {
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, _leftCameraLimitPosition, panSpeed * Time.deltaTime), 
                transform.position.y, transform.position.z);
        }
        if (_isMovingRight)
        {
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, _rightCameraLimitPosition, panSpeed * Time.deltaTime), 
                transform.position.y, transform.position.z);
        }
    }

    public void HoverLeft()
    {
        _isMovingLeft = true;
    }

    public void HoverRight()
    {
        _isMovingRight = true;
    }

    public void StopHover()
    {
        _isMovingLeft = false;
        _isMovingRight = false;
    }
}
