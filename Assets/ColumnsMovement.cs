using UnityEngine;

public class ColumnsMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        var columnsTransform = transform;
        columnsTransform.position += Time.deltaTime * moveSpeed * Vector3.left;
    }
}