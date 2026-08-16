using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "DevolutionEventChannel", menuName = "Events/DevolutionEventChannel")]
public class DevolutionEventChannel : ScriptableObject
{
    public UnityAction<Devolution> OnEventTriggered;

    public void RaiseEvent(Devolution arg0)
    {
        OnEventTriggered?.Invoke(arg0);
    }
}
