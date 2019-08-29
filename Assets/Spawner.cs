using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }

    [SerializeField] private GameObject columnsPrefab;
    [SerializeField]
    [Range(0, 2)]
    private float spawnDelay = 2f;
    [SerializeField]
    [Range(0, 6)]
    private float distanceToSpawn = 4.5f;
    [SerializeField]
    [Range(0, 3)]
    private float spawnHeight;

    private float nextSpawnTime;
    private float lastSpawnX = 8f;

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
    }

    private void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        float randomYPos = Random.Range(-spawnHeight, spawnHeight);
        float newSpawnX = lastSpawnX + distanceToSpawn;
        Vector2 newSpawnPos = new Vector2(newSpawnX, randomYPos);
        Instantiate(columnsPrefab, newSpawnPos, Quaternion.identity);
        lastSpawnX = newSpawnX;
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
