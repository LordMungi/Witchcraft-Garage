using UnityEngine;
using UnityEngine.UI;

public class GameButtonsUI : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private Button deliverButton;
    [SerializeField] private Button endDayButton;

    [Header("Listener Events")]
    [SerializeField] private DayEndDataEventChannel onDayEnding;

    private void OnEnable()
    {
        onDayEnding.OnEventTriggered += SetDayEndButtons;
    }
    private void OnDisable()
    {
        onDayEnding.OnEventTriggered -= SetDayEndButtons;
    }

    public void SetDayEndButtons(DayEndData d)
    {
        deliverButton.gameObject.SetActive(false);
        endDayButton.gameObject.SetActive(true);
    }

    public void StartDayButtons()
    {
        deliverButton.gameObject.SetActive(true);
        endDayButton.gameObject.SetActive(false);
    }
}
