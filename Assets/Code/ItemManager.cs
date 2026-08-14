using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] Collider2D shelfCollider;

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
            _grabbedItem.body.MovePosition(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        }
    }
    void Update()
    {
        if (_grabbedItem && clickAction.WasReleasedThisFrame())
        {
            if (shelfCollider.OverlapPoint(_grabbedItem.transform.position))
                _grabbedItem.ReturnToShelf();
            else
                _grabbedItem.Release();
            _grabbedItem = null;
        }
    }

    private void GrabItem(GrabbableItem item)
    {
        item.Grab();
        _grabbedItem = item;
    }
}
