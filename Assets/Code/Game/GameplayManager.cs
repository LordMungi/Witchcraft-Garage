using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private RequestManager requestManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Cauldron cauldron;
    [Space]
    [SerializeField] private int requestsPerDay = 5;

    [Header("Broadcast Events")]
    [SerializeField] private DayEndDataEventChannel onDayEnding;

    private List<Devolution> _devolutions = new List<Devolution>();
    private List<float> _dayAverages = new List<float>();
    private int _completedRequests = 0;
    private int _currentDay = 1;

    private bool _isPaused = false;

    private void Start()
    {
        _isPaused = false;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (!_isPaused)
                SetPause(true);
            else
                SetPause(false);
        }
    }

    public void DeliverPotion()
    {
        if (cauldron.itemsInPotion.Count > 0 && !requestManager.requestCompleted)
        {
            _devolutions.Add(requestManager.ComparePotion(cauldron.GetPotion()));
            _completedRequests++;
            cauldron.Refill();
        }

        if (_completedRequests >= requestsPerDay)
        {
            FinishDay();
        }
    }

    public void StartDay()
    {
        _devolutions.Clear();
        _completedRequests = 0;
        _currentDay++;

        cauldron.Refill();
    }

    private void FinishDay()
    {
        float dayAverage = GetRatingAverage();
        _dayAverages.Add(dayAverage);

        DayEndData dayEndData = new DayEndData();
        dayEndData.dayEnded = _currentDay;
        dayEndData.ratingAverage = dayAverage;

        onDayEnding.RaiseEvent(dayEndData);
    }

    private float GetRatingAverage()
    {
        float average = 0f;
        foreach (Devolution devolution in _devolutions)
        {
            average += devolution.rating;
        }
        return average / _devolutions.Count;
    }

    public void SetPause(bool arg)
    {
        uiManager.SetPauseScreen(arg);
        _isPaused = arg;
        Time.timeScale = arg ? 0f : 1f;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
