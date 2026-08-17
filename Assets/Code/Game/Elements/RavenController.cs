using UnityEngine;
using UnityEngine.EventSystems;

public class RavenController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Animator animator;

    [SerializeField] EventChannel onCreateRequest;
    [SerializeField] DevolutionEventChannel onDevolutionPosted;

    private void Start()
    {
        Arrive(new Devolution());
    }

    private void OnEnable()
    {
        onDevolutionPosted.OnEventTriggered += Arrive;
    }

    private void OnDisable()
    {
        onDevolutionPosted.OnEventTriggered -= Arrive;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        onCreateRequest.RaiseEvent();
        animator.SetTrigger("OnLeave");
    }

    public void Arrive(Devolution d)
    {
        animator.SetTrigger("OnArrive");
    }
}
