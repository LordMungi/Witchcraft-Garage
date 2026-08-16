using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "DayEndDataEventChannel", menuName = "Events/DayEndDataEventChannel")]
public class DayEndDataEventChannel : ScriptableObject
{
    public UnityAction<DayEndData> OnEventTriggered;

    public void RaiseEvent(DayEndData arg0)
    {
        OnEventTriggered?.Invoke(arg0);
    }
}
