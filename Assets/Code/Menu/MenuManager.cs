using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenLink(string url)
    {
        Application.OpenURL(url);
    }
}
