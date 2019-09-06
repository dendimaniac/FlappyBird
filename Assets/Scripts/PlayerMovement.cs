using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IPlayerMovementController
{
    public PlayerController playerController;
    public static PlayerMovement Instance { get; private set; }

    [SerializeField] private float jumpForce = 400f;
    public float JumpForce => jumpForce;

    public Vector2 Position
    {
        get => transform.position;
        set => transform.position = value;
    }

    [SerializeField] [Range(4.5f, 5)] private float maxHeight = 4.5f;

    public float MaxHeight => maxHeight;

    private Rigidbody2D rb2D;

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

        rb2D = GetComponent<Rigidbody2D>();
        playerController = new PlayerController(this, rb2D);
    }

    private void Update()
    {
        playerController.CheckReachMaxHeight();
    }
}