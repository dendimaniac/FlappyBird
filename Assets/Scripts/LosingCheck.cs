using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LosingCheck : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerStay2D(Collider2D other)
    {
        if (NotPlayer(other)) return;
        MenuManager.Instance.ToggleCanvas(MenuName.Lose);
        if (CanSaveHighScore())
        {
            HighScoreController.SaveHighScore(ScoreCheck.CurrentScore);
        }

        GameManager.Instance.DisablePlayerControls();
        if (!PlayerDeath.DidDie)
        {
            AudioManager.Instance.StopSounds();
            AudioManager.Instance.PlaySound("Death");
            PlayerDeath.DidDie = true;
        }

        UiManager.Instance.UpdateHighScore();
    }

    private bool CanSaveHighScore()
    {
        return ScoreCheck.CurrentScore > HighScoreController.LoadHighScore();
    }

    private bool NotPlayer(Collider2D other)
    {
        return !other.gameObject.CompareTag(playerTag);
    }
}