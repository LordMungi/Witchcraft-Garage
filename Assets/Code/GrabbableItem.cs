using UnityEngine;
using UnityEngine.EventSystems;

public class GrabbableItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ItemStats stats;

    private Rigidbody2D _body;
    private Vector3 _defaultPosition;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _body.bodyType = RigidbodyType2D.Static;

        _defaultPosition = transform.position;
    }

    void Update()
    {
        
    }

    public void ReturnToShelf()
    {
        _body.bodyType = RigidbodyType2D.Static;

        transform.position = _defaultPosition;

    }

    public void Grab()
    {
        _body.bodyType = RigidbodyType2D.Kinematic;
    }

    public void Release()
    {
        _body.bodyType = RigidbodyType2D.Dynamic;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked item: " + name);
    }
}
