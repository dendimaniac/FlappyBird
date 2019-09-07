using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
public class ScoreCheck : MonoBehaviour
{
    public static int CurrentScore;

    private void Awake()
    {
        CurrentScore = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        CurrentScore++;
        UiManager.Instance.UpdateScore(CurrentScore);
    }
}
