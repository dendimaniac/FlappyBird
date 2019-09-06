using UnityEngine;

public interface IPlayerMovementController
{
    Vector2 Position { get; set; }
    float JumpForce { get; }
    float MaxHeight { get; }
}