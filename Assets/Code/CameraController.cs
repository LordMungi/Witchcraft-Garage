using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform camera1Position;
    [SerializeField] private Transform camera2Position;
    [Space]
    [SerializeField] private float panSpeed = 20;

    [Header("Listener Events")]
    [SerializeField] private EventChannel onLeftTriggerEnterUI;
    [SerializeField] private EventChannel onLeftTriggerExitUI;
    [SerializeField] private EventChannel onRightTriggerEnterUI;
    [SerializeField] private EventChannel onRightTriggerExitUI;

    private bool _isMovingLeft = false;
    private bool _isMovingRight = false;

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
            transform.position = Vector3.MoveTowards(transform.position, camera2Position.position, panSpeed * Time.deltaTime);
        }
        if (_isMovingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, camera1Position.position, panSpeed * Time.deltaTime);
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
