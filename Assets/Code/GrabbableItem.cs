using UnityEngine;
using UnityEngine.EventSystems;

public class GrabbableItem : MonoBehaviour, IPointerDownHandler
{
    [Header("Parameters")]
    [SerializeField] ItemStats stats;

    [Header("Broadcast Events")]
    [SerializeField] ItemEventChannel onItemGrabbed;

    public Rigidbody2D body;

    private Vector3 _defaultPosition;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.bodyType = RigidbodyType2D.Static;

        _defaultPosition = transform.position;
    }

    void Update()
    {
        
    }

    public void ReturnToShelf()
    {
        body.bodyType = RigidbodyType2D.Static;

        transform.position = _defaultPosition;

    }

    public void Grab()
    {
        body.bodyType = RigidbodyType2D.Kinematic;
    }

    public void Release()
    {
        body.bodyType = RigidbodyType2D.Dynamic;
        body.linearVelocity = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked item: " + name);
        onItemGrabbed.RaiseEvent(this);
        Grab();
    }
}
