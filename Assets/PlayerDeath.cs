using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private string columnTag;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(columnTag))
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerInput>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
