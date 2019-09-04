using System;
using UnityEngine;

public class ColumnsMovement : MonoBehaviour
{
    [SerializeField] private float baseMoveSpeed = 3f;
    [SerializeField] private float maxMoveSpeed = 4f;

    private float currentMoveSpeed;

    public static bool canMove;

    private void Awake()
    {
        canMove = true;
        currentMoveSpeed = baseMoveSpeed;
    }

    private void Update()
    {
        if (!canMove) return;
        var columnsTransform = transform;
        Move(columnsTransform);
        TryIncreaseSpeed();
    }

    private void Move(Transform columnsTransform)
    {
        Debug.Log(currentMoveSpeed);
        columnsTransform.position += Time.fixedDeltaTime * currentMoveSpeed * Vector3.left;
    }

    private void TryIncreaseSpeed()
    {
        if (currentMoveSpeed >= maxMoveSpeed) return;
        currentMoveSpeed += Time.fixedDeltaTime;
    }
}