using System.Timers;
using TMPro;
using UnityEngine;

public class CounterMenu : Menu
{
    [SerializeField] private int maxCounter = 3;

    private Timer timer = new Timer(1000);
    private int currentCounter;

    private TextMeshProUGUI counterText;

    private void Awake()
    {
        timer.Elapsed += (sender, e) => currentCounter--;
        
        counterText = GetComponentInChildren<TextMeshProUGUI>();
        currentCounter = maxCounter;
    }

    private void OnEnable()
    {
        timer.Start();
    }

    private void OnDisable()
    {
        currentCounter = maxCounter;
        timer.Stop();
    }

    private void Update()
    {
        UpdateCounter();
        if (currentCounter > 0) return;
        
        UiManager.Instance.TogglePause();
        MenuManager.Instance.ToggleCanvas(MenuName.Score);
    }

    private void UpdateCounter()
    {
        counterText.text = currentCounter.ToString();
    }
}
