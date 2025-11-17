using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public float verticalSpeed = 2f;         // slower/faster than EnemyOne
    public float horizontalAmplitude = 2f;   // how far it swings side to side
    public float horizontalFrequency = 2f;   // how fast it zigzags

    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        // Move downward
        transform.position += Vector3.down * verticalSpeed * Time.deltaTime;

        // Add horizontal zig-zag movement
        float xOffset = Mathf.Sin(Time.time * horizontalFrequency) * horizontalAmplitude;
        transform.position = new Vector3(startX + xOffset, transform.position.y, transform.position.z);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (player.hasShield)
                {
                    // use up the shield instead of killing the player
                    player.ConsumeShield();
                }
                else
                {
                    // no shield: normal death behavior
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
