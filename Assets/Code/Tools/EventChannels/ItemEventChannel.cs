using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ItemEventChannel", menuName = "Events/ItemEventChannel")]
public class ItemEventChannel : ScriptableObject
{
    public UnityAction<GrabbableItem> OnEventTriggered;

    public void RaiseEvent(GrabbableItem arg0)
    {
        OnEventTriggered?.Invoke(arg0);
    }
}
