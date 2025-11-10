using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifetime = 3f;  // seconds before the coin disappears
    public int scoreValue = 1;   // points player earns

    private void Start()
    {
        // auto-destroy after lifetime expires
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // add score
            ScoreManager.instance.AddScore(scoreValue);
            Destroy(gameObject); // remove coin
        }
    }
}
