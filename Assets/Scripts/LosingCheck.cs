using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LosingCheck : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    private void OnCollisionStay2D(Collision2D other)
    {
        if (NotPlayer(other)) return;
        MenuManager.Instance.ToggleCanvas(MenuName.Lose);
        if (CanSaveHighScore())
        {
            HighScoreController.SaveHighScore(ScoreCheck.CurrentScore);
        }
        
        GameManager.Instance.DisablePlayerControls();
        UiManager.Instance.UpdateHighScore();
    }

    private bool CanSaveHighScore()
    {
        return ScoreCheck.CurrentScore > HighScoreController.LoadHighScore();
    }

    private bool NotPlayer(Collision2D other)
    {
        return !other.gameObject.CompareTag(playerTag);
    }
}