using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class RequestLetterUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [Header("Properties")]
    [SerializeField] RectTransform letter;
    [SerializeField] Transform hiddenPosition;
    [SerializeField] Transform peekPosition;
    [SerializeField] Transform shownPosition;
    [SerializeField] TextMeshProUGUI requestText;
    [SerializeField] float moveSpeed = 100;

    [Header("Listener Events")]
    [SerializeField] RequestEventChannel onRequestPosted;
    [SerializeField] DevolutionEventChannel onReviewPosted;

    private bool _isEnabled;
    private bool _isShowing;

    private void OnEnable()
    {
        onRequestPosted.OnEventTriggered += UpdateRequest;
        onReviewPosted.OnEventTriggered += HideRequest;
    }

    private void OnDisable()
    {
        onRequestPosted.OnEventTriggered -= UpdateRequest;
        onReviewPosted.OnEventTriggered -= HideRequest;
    }

    void Start()
    {
        _isEnabled = false;
        letter.position = hiddenPosition.position;
    }

    void Update()
    {
        if (_isEnabled)
        {
            if (_isShowing)
                letter.position = Vector3.MoveTowards(letter.position, shownPosition.position, moveSpeed * Time.deltaTime);
            else
                letter.position = Vector3.MoveTowards(letter.position, peekPosition.position, moveSpeed * Time.deltaTime);
        }
        else
            letter.position = Vector3.MoveTowards(letter.position, hiddenPosition.position, moveSpeed * Time.deltaTime);
    }

    private void UpdateRequest(Request request)
    {
        requestText.text = request.text;
        _isEnabled = true;
    }

    private void HideRequest(Devolution devolution)
    {
        _isEnabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isShowing = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isShowing = false;
    }
}
