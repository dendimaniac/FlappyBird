using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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
    
    public void DisablePlayerControls(GameObject player)
    {
        ColumnsMovement.CanMove = false;
        player.GetComponent<SpriteRenderer>().color = Color.red;
        player.GetComponent<PlayerMovement>().playerController.StopVerticalMovement();
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerInput>().enabled = false;
    }
}