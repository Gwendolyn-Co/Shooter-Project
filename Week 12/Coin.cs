using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    public float lifetime = 3f;      // total lifetime
    public float blinkTime = 1f;     // last X seconds to blink
    public int scoreValue = 1;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(LifetimeCoroutine());
    }

    private IEnumerator LifetimeCoroutine()
    {
        float timer = 0f;

        // normal lifetime before blinking
        while (timer < lifetime - blinkTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        // start blinking
        float blinkTimer = 0f;
        bool visible = true;
        while (timer < lifetime)
        {
            timer += Time.deltaTime;
            blinkTimer += Time.deltaTime;

            if (blinkTimer >= 0.2f) // blink interval
            {
                blinkTimer = 0f;
                visible = !visible;
                spriteRenderer.enabled = visible;
            }

            yield return null;
        }

        Destroy(gameObject); // finally destroy coin
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.gameObject.layer == 7)
        {
            ScoreManager.instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
