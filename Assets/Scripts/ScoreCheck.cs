using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
public class ScoreCheck : MonoBehaviour
{
    [SerializeField] private string scoreTag = "ScoreText";
    
    private TextMeshProUGUI scoreText;

    public static int CurrentScore;

    private void Awake()
    {
        CurrentScore = 0;
        scoreText = GameObject.FindWithTag(scoreTag).GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        CurrentScore++;
        scoreText.text = CurrentScore.ToString();
    }
}
