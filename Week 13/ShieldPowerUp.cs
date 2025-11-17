using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float shieldDuration = 5f; // how long the shield lasts

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            // Activate the shield on the player
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.ActivateShield(shieldDuration);
            }

            Destroy(gameObject); // destroy the shield pickup
        }
    }
}
