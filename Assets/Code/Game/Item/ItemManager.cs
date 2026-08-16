using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] Collider2D shelfCollider;

    [Header("Listener Events")]
    [SerializeField] ItemEventChannel onItemGrabbed;
    [SerializeField] ItemEventChannel onItemAddedToPotion;
    [SerializeField] ItemEventChannel onItemRemovedFromPotion;

    InputAction clickAction;

    private Item _grabbedItem = null;

    private void OnEnable()
    {
        onItemGrabbed.OnEventTriggered += GrabItem;
        onItemAddedToPotion.OnEventTriggered += HideItem;
        onItemRemovedFromPotion.OnEventTriggered += ReturnItem;
    }

    private void OnDisable()
    {
        onItemGrabbed.OnEventTriggered -= GrabItem;
        onItemAddedToPotion.OnEventTriggered -= HideItem;
        onItemRemovedFromPotion.OnEventTriggered -= ReturnItem;
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

    private void GrabItem(Item item)
    {
        item.Grab();
        _grabbedItem = item;
    }

    private void HideItem(Item item)
    {
        item.gameObject.SetActive(false);
    }

    private void ReturnItem(Item item)
    {
        item.gameObject.SetActive(true);
        item.ReturnToShelf();
    }
}
