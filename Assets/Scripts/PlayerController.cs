using UnityEngine;

public class PlayerController
{
    private IPlayerMovementController movementController;
    private Rigidbody2D rb2D;

    public PlayerController(IPlayerMovementController playerMovementController, Rigidbody2D rigidbody2D)
    {
        movementController = playerMovementController;
        rb2D = rigidbody2D;
    }

    public void Jump()
    {
        StopVerticalMovement();
        rb2D.AddForce(new Vector2(0f, movementController.JumpForce));
    }

    public void StopVerticalMovement()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);
    }

    public void CheckReachMaxHeight()
    {
        if (movementController.Position.y < movementController.MaxHeight) return;
        movementController.Position = new Vector2(movementController.Position.x, movementController.MaxHeight);
        StopVerticalMovement();
    }
}