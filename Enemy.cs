using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 3f);
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
