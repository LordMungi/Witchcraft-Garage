using UnityEngine;
using UnityEngine.EventSystems;

public class UICollider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Broadcast Events")]
    [SerializeField] private EventChannel UIMouseEnter;
    [SerializeField] private EventChannel UIMouseExit;

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIMouseEnter.RaiseEvent();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIMouseExit.RaiseEvent();
    }
}
