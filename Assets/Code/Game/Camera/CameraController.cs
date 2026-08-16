using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private CameraSection[] cameraSections;
    [SerializeField, Range(0, 10)] private int startingCameraSection = 1;
    [Space]
    [SerializeField] private float panSpeed = 20;
    [SerializeField] private float fastPanSpeed = 200;

    [Header("Listener Events")]
    [SerializeField] private EventChannel onLeftTriggerEnterUI;
    [SerializeField] private EventChannel onLeftTriggerExitUI;
    [SerializeField] private EventChannel onRightTriggerEnterUI;
    [SerializeField] private EventChannel onRightTriggerExitUI;

    private Camera _camera;

    public static CameraSection CurrentCameraSection;
    private int _currentCameraSectionIndex = 0;

    private bool _isMovingLeft = false;
    private bool _isMovingRight = false;

    private void Start()
    {
        _camera = GetComponent<Camera>();


        float aspect = _camera.aspect > 16f / 9f ? 16f / 9f : _camera.aspect;
        float cameraWidth = _camera.orthographicSize * aspect;

        for (int i = 0; i < cameraSections.Length; i++)
        {
            cameraSections[i].limitLeftPosition = cameraSections[i].limitLeft.position.x + cameraWidth;
            cameraSections[i].limitRightPosition = cameraSections[i].limitRight.position.x - cameraWidth;
        }

        _currentCameraSectionIndex = Mathf.Min(startingCameraSection, cameraSections.Length);
        CurrentCameraSection = cameraSections[_currentCameraSectionIndex];

        transform.position = new Vector3(CurrentCameraSection.center.position.x, CurrentCameraSection.center.position.y, transform.position.z);
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
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, CurrentCameraSection.limitLeftPosition, panSpeed * Time.deltaTime), 
                transform.position.y, transform.position.z);
        }
        if (_isMovingRight)
        {
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, CurrentCameraSection.limitRightPosition, panSpeed * Time.deltaTime), 
                transform.position.y, transform.position.z);
        }
    }

    public void HoverLeft()
    {
        _isMovingLeft = true;

        if (Mathf.Abs(transform.position.x - CurrentCameraSection.limitLeftPosition) <= Mathf.Epsilon)
        {
            if (_currentCameraSectionIndex > 0)
            {
                _currentCameraSectionIndex--;
                CurrentCameraSection = cameraSections[_currentCameraSectionIndex];
                transform.position = new Vector3(CurrentCameraSection.center.position.x, CurrentCameraSection.center.position.y, transform.position.z);
                StopHover();
            }
        }
    }

    public void HoverRight()
    {
        _isMovingRight = true;

        if (Mathf.Abs(transform.position.x - CurrentCameraSection.limitRightPosition) <= Mathf.Epsilon)
        {
            if (_currentCameraSectionIndex < cameraSections.Length - 1)
            {
                _currentCameraSectionIndex++;
                CurrentCameraSection = cameraSections[_currentCameraSectionIndex];
                transform.position = new Vector3(CurrentCameraSection.center.position.x, CurrentCameraSection.center.position.y, transform.position.z);
                StopHover();
            }
        }
    }

    public void StopHover()
    {
        _isMovingLeft = false;
        _isMovingRight = false;
    }
}
