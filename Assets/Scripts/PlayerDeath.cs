using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private string columnTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(columnTag) || GetComponent<PlayerMovement>().enabled == false) return;
        ColumnsMovement.canMove = false;
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<PlayerMovement>().playerController.StopVerticalMovement();
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerInput>().enabled = false;
    }
}
