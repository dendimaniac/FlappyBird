using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LosingCheck : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            GameManager.Instance.Retry();
        }
    }
}
