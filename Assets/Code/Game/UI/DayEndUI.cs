using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayEndUI : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI nextDayButtonText;
    [SerializeField] private Image starsImage;

    [Header("ListenerEvents")]
    [SerializeField] private DayEndDataEventChannel onDayEnding;

    private void OnEnable()
    {
        onDayEnding.OnEventTriggered += SetDayEndUI;
    }

    private void OnDisable()
    {
        onDayEnding.OnEventTriggered -= SetDayEndUI;
    }
    
    private void SetDayEndUI(DayEndData data)
    {
        titleText.text = "Day " + data.dayEnded + " ended!";
        nextDayButtonText.text = "To day " + (data.dayEnded + 1);
        starsImage.fillAmount = data.ratingAverage / 10;
    }
}
