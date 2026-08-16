using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Parameters")]
    [SerializeField] public Statistics stats;
    [SerializeField] public string description;

    [Header("Broadcast Events")]
    [SerializeField] ItemEventChannel onItemGrabbed;
    [SerializeField] ItemEventChannel onItemHoverEnter;
    [SerializeField] ItemEventChannel onItemHoverExit;

    [Header("Public Properties")]
    public Rigidbody2D body;
    public bool isGrabbed;

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
        isGrabbed = false;
    }

    public void Grab()
    {
        body.bodyType = RigidbodyType2D.Kinematic;
        body.linearVelocity = Vector3.zero;
        body.angularVelocity = 0;
        isGrabbed = true;
    }

    public void Release()
    {
        body.bodyType = RigidbodyType2D.Dynamic;
        body.linearVelocity = Vector3.zero;
        isGrabbed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onItemGrabbed.RaiseEvent(this);
        Grab();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onItemHoverEnter.RaiseEvent(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onItemHoverExit.RaiseEvent(this);
    }
}
