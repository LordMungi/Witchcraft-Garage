using TMPro;
using UnityEngine;

public class ItemPopupUI : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private CanvasRenderer canvas;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;

    [Header("Listener Events")]
    [SerializeField] private ItemEventChannel onItemHoverEnter;
    [SerializeField] private ItemEventChannel onItemHoverExit;

    private Item _followedItem = null;

    private void Start()
    {
        canvas.gameObject.SetActive(false);
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
            transform.position = item.transform.position;
            itemNameText.text = item.name;
            itemDescriptionText.text = item.description;
            _followedItem = item;
            canvas.gameObject.SetActive(true);
        }
    }

    private void HidePopup(Item item)
    {
        canvas.gameObject.SetActive(false);
        _followedItem = null;
    }
}
