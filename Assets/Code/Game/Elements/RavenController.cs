using UnityEngine;
using UnityEngine.EventSystems;

public class RavenController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Animator[] animators;

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
        foreach (Animator animator in animators)
        {
            animator.SetTrigger("OnLeave");
        }
    }

    public void Arrive(Devolution d)
    {
        foreach (Animator animator in animators)
        {
            animator.SetTrigger("OnArrive");
        }
    }
}
