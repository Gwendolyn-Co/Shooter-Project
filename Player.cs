using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //how to define a variable
    //1. access modifier: public or private
    //2. data type: int, float, bool, string
    //3. variable name: camelCase
    //4. value: optional

    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 4.5f;

    public GameObject bulletPrefab;
    public float bulletForce = 5f;

    private bool isShieldActive = false;
    private float shieldTimer = 0f;
    public GameObject shieldVisual;
    public bool hasShield = false;

    public AudioSource audioSource;
    public AudioClip shieldPickupClip;
    public AudioClip shieldBreakClip;


    void Start()
    {
        playerSpeed = 6f;
        //This function is called at the start of the game
        
        if (shieldVisual != null) {
            shieldVisual.SetActive(false);
        }
    }

    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();

        // Handle shield duration
        if (isShieldActive)
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0)
            {
                ConsumeShield();
            }
    }

    }

    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // spawn at player's position
        Vector3 spawnPos = transform.position; 
        // or: transform.position + transform.up * 0.5f;

         GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

        // add force if it has a Rigidbody2D
        // Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // if (rb != null)
        // {
        //     rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        // }
}

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

        // Horizontal wrap-around (same as before)
        if(transform.position.x > horizontalScreenLimit)
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, 0);
        else if(transform.position.x < -horizontalScreenLimit)
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, 0);

        // Vertical restriction: stay in bottom half
        float bottomLimit = -verticalScreenLimit;   // bottom of screen
        float middleLimit = 0f;                     // middle of screen
        transform.position = new Vector3(transform.position.x,
                                         Mathf.Clamp(transform.position.y, bottomLimit, middleLimit),
                                         0);
    }

    public void ActivateShield(float duration)
    {
        hasShield = true;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(true);
        }

        if (audioSource != null && shieldPickupClip != null)
        {
            audioSource.PlayOneShot(shieldPickupClip);
        }
    }

    public void ConsumeShield()
    {
        hasShield = false;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }

        if (audioSource != null && shieldBreakClip != null)
        {
            audioSource.PlayOneShot(shieldBreakClip);
        }
    }



}

