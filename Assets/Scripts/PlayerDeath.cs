using System.Security.Policy;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private string columnTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsDead(other)) return;
        
        GameManager.Instance.DisablePlayerControls();
    }

    private bool IsDead(Collider2D other)
    {
        return !other.gameObject.CompareTag(columnTag) || GetComponent<PlayerMovement>().enabled == false;
    }
}