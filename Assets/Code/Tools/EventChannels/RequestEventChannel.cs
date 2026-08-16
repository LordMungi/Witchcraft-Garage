using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "RequestEventChannel", menuName = "Events/RequestEventChannel")]
public class RequestEventChannel : ScriptableObject
{
    public UnityAction<Request> OnEventTriggered;

    public void RaiseEvent(Request arg0)
    {
        OnEventTriggered?.Invoke(arg0);
    }
}
