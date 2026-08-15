using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler
{
    [Header("Parameters")]
    [SerializeField] Statistics stats;

    [Header("Broadcast Events")]
    [SerializeField] ItemEventChannel onItemGrabbed;

    [Header("Public Properties")]
    public Rigidbody2D body;

    private Vector3 _defaultPosition;
    private Quaternion _defaultRotation;
    private Vector3 _defaultScale;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.bodyType = RigidbodyType2D.Static;

        _defaultPosition = transform.position;
        _defaultRotation = transform.rotation;
        _defaultScale = transform.localScale;
    }

    void Update()
    {
        
    }

    public void ReturnToShelf()
    {
        body.bodyType = RigidbodyType2D.Static;

        transform.position = _defaultPosition;
        transform.rotation = _defaultRotation;
        transform.localScale = _defaultScale;
    }

    public void Grab()
    {
        body.bodyType = RigidbodyType2D.Kinematic;
        body.linearVelocity = Vector3.zero;
        body.angularVelocity = 0;
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
