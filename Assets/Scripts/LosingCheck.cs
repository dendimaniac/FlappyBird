using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LosingCheck : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (NotPlayer(other)) return;
        GameManager.Instance.Retry();
        
        if (CanSaveHighScore())
        {
            HighScore.SaveHighScore(ScoreCheck.CurrentScore);
        }
    }

    private bool CanSaveHighScore()
    {
        return ScoreCheck.CurrentScore > HighScore.LoadHighScore();
    }

    private bool NotPlayer(Collider2D other)
    {
        return !other.gameObject.CompareTag(playerTag);
    }
}
