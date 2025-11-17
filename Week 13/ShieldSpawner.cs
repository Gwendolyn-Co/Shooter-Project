using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    public GameObject shieldPowerUpPrefab;
    
    // time between spawns
    public float minSpawnInterval = 30f;
    public float maxSpawnInterval = 60f;

    // area where shield can spawn
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;

    private void Start()
    {
        // start first spawn timer
        ScheduleNextSpawn();
    }

    void ScheduleNextSpawn()
    {
        float delay = Random.Range(minSpawnInterval, maxSpawnInterval);
        Invoke("SpawnShield", delay);
    }

    void SpawnShield()
    {
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        Instantiate(shieldPowerUpPrefab, new Vector2(x, y), Quaternion.identity);

        // schedule the next one
        ScheduleNextSpawn();
    }
}
