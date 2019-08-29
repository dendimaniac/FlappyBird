using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }

    [SerializeField] private GameObject columnsPrefab;
    [SerializeField] [Range(0, 7)] private int spawnAmount = 6;
    [SerializeField] [Range(0, 6)] private float distanceToSpawn = 5;
    [SerializeField] [Range(0, 3)] private float spawnHeight;
    [SerializeField] private Vector2 startPosition;

    private GameObject finalSpawn;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Spawn();
    }

    private void Spawn()
    {
        float nextSpawnX = startPosition.x;
        for (var i = 0; i < spawnAmount; i++)
        {
            float randomSpawnY = Random.Range(-spawnHeight, spawnHeight);
            Vector2 newSpawnPos = new Vector2(nextSpawnX, randomSpawnY);
            GameObject instantiatedCol = Instantiate(columnsPrefab, newSpawnPos, Quaternion.identity);
            nextSpawnX += distanceToSpawn;
            if (i != spawnAmount - 1) continue;
            instantiatedCol.GetComponent<ColumnsReset>().isLast = true;
            finalSpawn = instantiatedCol;
        }
    }

    public void ResetColumns(Transform columnsTransform)
    {
        float randomSpawnY = Random.Range(-spawnHeight, spawnHeight);
        columnsTransform.position = new Vector2(GetNextSpawnX(), randomSpawnY);
        columnsTransform.GetComponent<ColumnsReset>().isLast = true;
        finalSpawn = columnsTransform.gameObject;
    }

    private float GetNextSpawnX()
    {
        float nextSpawnX = 0f;
        finalSpawn.GetComponent<ColumnsReset>().isLast = false;
        nextSpawnX = finalSpawn.transform.position.x;
        return nextSpawnX + distanceToSpawn;
    }
}