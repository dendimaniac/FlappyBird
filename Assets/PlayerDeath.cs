using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private string columnTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(columnTag))
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerInput>().enabled = false;
            GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
}
