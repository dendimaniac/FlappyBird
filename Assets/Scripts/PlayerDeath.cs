using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private string columnTag = "Columns";

    public static bool DidDie;

    private void Awake()
    {
        DidDie = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CantDie(other)) return;

        GameManager.Instance.DisablePlayerControls();

        if (DidDie) return;
        
        AudioManager.Instance.StopSounds();
        AudioManager.Instance.PlaySound("Death");
        DidDie = true;
    }

    private bool CantDie(Collider2D other)
    {
        return !other.gameObject.CompareTag(columnTag) || GetComponent<PlayerMovement>().enabled == false;
    }
}