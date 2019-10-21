using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;
    private Collider2D playerCollider;
    [HideInInspector] public PlayerInput playerInput;

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
        
        player = GameObject.FindWithTag("Player");
        playerInput = player.GetComponent<PlayerInput>();
        playerMovement = player.GetComponent<PlayerMovement>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    public void DisablePlayerControls()
    {
        ColumnsMovement.CanMove = false;
        spriteRenderer.color = Color.red;
        playerMovement.playerController.StopVerticalMovement();
        playerMovement.enabled = false;
        playerInput.enabled = false;
    }
}