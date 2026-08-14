using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] Camera mainCamera;

    [Header("Listener Events")]
    [SerializeField] ItemEventChannel onItemGrabbed;

    InputAction clickAction;

    private GrabbableItem _grabbedItem = null;

    private void OnEnable()
    {
        onItemGrabbed.OnEventTriggered += GrabItem;
    }

    private void OnDisable()
    {
        onItemGrabbed.OnEventTriggered -= GrabItem;
    }

    private void Awake()
    {
        clickAction = InputSystem.actions.FindAction("Click");
    }

    private void FixedUpdate()
    {
        if (_grabbedItem)
        {

            _grabbedItem.body.MovePosition(mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        }
    }
    void Update()
    {
        if (clickAction.WasReleasedThisFrame())
        {
            _grabbedItem?.Release();
            _grabbedItem = null;
        }
    }

    private void GrabItem(GrabbableItem item)
    {
        item.Grab();
        _grabbedItem = item;
    }
}
