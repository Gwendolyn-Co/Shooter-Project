using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 5f;
    public Vector2 spawnAreaMin; // bottom-left corner of spawn area
    public Vector2 spawnAreaMax; // top-right corner of spawn area

    private void Start()
    {
        InvokeRepeating("SpawnCoin", 1f, spawnInterval);
    }

    void SpawnCoin()
    {
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Instantiate(coinPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
