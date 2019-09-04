using UnityEngine;

public interface IPlayerMovementController
{
    Vector3 Position { get; set; }
    float JumpForce { get; }
    float MaxHeight { get; }
}