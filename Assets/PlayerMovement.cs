using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    [SerializeField] private float flyForce;
    [SerializeField] [Range(4.5f, 5)] private float maxHeight;

    private Rigidbody2D rb2D;
    private Transform playerTransform;

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
        playerTransform = transform;
    }

    public void Jump()
    {
        StopVerticalMovement();
        rb2D.AddForce(new Vector2(0f, flyForce));
    }

    private void Update()
    {
        if (transform.position.y < maxHeight) return;
        playerTransform.position = new Vector2(playerTransform.position.x, maxHeight);
        StopVerticalMovement();
    }

    public void StopVerticalMovement()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);
    }
}