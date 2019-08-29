using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    [SerializeField] private float moveSpeed;
    [SerializeField] private float flyForce;

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
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }

    public void FlyUp()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);
        rb2D.AddForce(new Vector2(0f, flyForce));
    }
}
