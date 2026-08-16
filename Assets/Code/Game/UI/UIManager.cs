using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] CanvasRenderer exitConfirmCanvas;
    [SerializeField] CanvasRenderer endDayCanvas;

    public void SetEndDayCanvas(bool arg)
    {
        endDayCanvas.gameObject.SetActive(arg);
    }

    public void SetExitConfirmScreen(bool arg)
    {
        exitConfirmCanvas.gameObject.SetActive(arg);
    }

}
