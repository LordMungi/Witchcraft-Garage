using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ItemEventChannel", menuName = "Events/ItemEventChannel")]
public class ItemEventChannel : ScriptableObject
{
    public UnityAction<Item> OnEventTriggered;

    public void RaiseEvent(Item arg0)
    {
        OnEventTriggered?.Invoke(arg0);
    }
}
