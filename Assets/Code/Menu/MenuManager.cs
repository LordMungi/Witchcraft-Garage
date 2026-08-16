using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] Canvas mainMenuCanvas;
    [SerializeField] Canvas settingsCanvas;
    [SerializeField] Canvas creditsCanvas;

    public void SetMainMenu(bool arg)
    {
        mainMenuCanvas.gameObject.SetActive(arg);
    }

    public void SetSettings(bool arg)
    {
        settingsCanvas.gameObject.SetActive(arg);
    }

    public void SetCredits(bool arg)
    {
        creditsCanvas.gameObject.SetActive(arg);
    }
}
