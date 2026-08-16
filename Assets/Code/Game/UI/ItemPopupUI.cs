using TMPro;
using UnityEngine;

public class ItemPopupUI : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private RectTransform canvasRect;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private float paddingFromItem = 10;

    [Header("Listener Events")]
    [SerializeField] private ItemEventChannel onItemHoverEnter;
    [SerializeField] private ItemEventChannel onItemHoverExit;

    private Item _followedItem = null;
    private void Start()
    {
        canvasRect.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_followedItem)
            if (_followedItem.isGrabbed)
                HidePopup(_followedItem);
    }

    private void OnEnable()
    {
        onItemHoverEnter.OnEventTriggered += ShowPopup;
        onItemHoverExit.OnEventTriggered += HidePopup;
    }

    private void OnDisable()
    {
        onItemHoverEnter.OnEventTriggered -= ShowPopup;
        onItemHoverExit.OnEventTriggered -= HidePopup;
    }

    private void ShowPopup(Item item)
    {
        if (!_followedItem)
        {
            float positionX = item.transform.position.x < CameraController.CurrentCameraSection.center.position.x ?
                item.transform.position.x + canvasRect.rect.size.x / 2 : item.transform.position.x - canvasRect.rect.size.x / 2;

            float positionY = item.transform.position.y < CameraController.CurrentCameraSection.center.position.y ?
                item.transform.position.y + paddingFromItem : item.transform.position.y - paddingFromItem;

            transform.position = new Vector3(positionX, positionY, transform.position.z);
            itemNameText.text = item.name;
            itemDescriptionText.text = item.description;
            _followedItem = item;
            canvasRect.gameObject.SetActive(true);
        }
    }

    private void HidePopup(Item item)
    {
        canvasRect.gameObject.SetActive(false);
        _followedItem = null;
    }
}
