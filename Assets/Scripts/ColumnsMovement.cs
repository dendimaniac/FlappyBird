using UnityEngine;

public class ColumnsMovement : MonoBehaviour
{
    [SerializeField] private float baseMoveSpeed = 3f;
    [SerializeField] private float maxMoveSpeed = 4f;
    [SerializeField] private int difficultyThreshold = 50;

    private float currentMoveSpeed;

    public static bool CanMove;

    private void Awake()
    {
        CanMove = true;
        currentMoveSpeed = baseMoveSpeed;
    }

    private void Update()
    {
        if (!CanMove) return;
        var columnsTransform = transform;
        Move(columnsTransform);
        TryIncreaseSpeed();
    }

    private void Move(Transform columnsTransform)
    {
        columnsTransform.position += Time.fixedDeltaTime * currentMoveSpeed * Vector3.left;
    }

    private void TryIncreaseSpeed()
    {
        if (CanAccelerate())
        {
            currentMoveSpeed += Time.fixedDeltaTime;
        }
    }

    private bool CanAccelerate()
    {
        return !(currentMoveSpeed >= maxMoveSpeed) && ScoreCheck.CurrentScore % difficultyThreshold == 0;
    }
}