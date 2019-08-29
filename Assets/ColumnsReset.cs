using UnityEngine;

public class ColumnsReset : MonoBehaviour
{
    [SerializeField] [Range(0, 3)] private float heightRange;

    [HideInInspector] public bool isLast = false;

    private void Update()
    {
        var columnsTransform = transform;
        if (!(columnsTransform.position.x <= -10f)) return;
        Spawner.Instance.ResetColumns(columnsTransform);
    }
}