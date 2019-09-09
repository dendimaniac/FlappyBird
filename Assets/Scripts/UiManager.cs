using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UiManager: MonoBehaviour
{
    public static UiManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    
    private bool isOpened = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        if (!Input.GetButtonDown("Cancel"))
        {
            return;
        }
        TogglePause();
    }
    
    public void TogglePause()
    {
        MenuManager.Instance.ToggleCanvas(isOpened ? MenuName.Score : MenuName.Pause);
        Time.timeScale = isOpened ? 1 : 0;
        ColumnsMovement.CanMove = isOpened;
        GameManager.Instance.playerInput.enabled = isOpened;
        isOpened = !isOpened;
    }
    
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHighScore()
    {
        highScoreText.text = HighScoreController.LoadHighScore().ToString();
    }
}