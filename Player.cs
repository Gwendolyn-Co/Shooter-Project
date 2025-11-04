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
    private float verticalScreenLimit = 6.5f;

    public GameObject bulletPrefab;

    void Start()
    {
        playerSpeed = 6f;
        //This function is called at the start of the game
        
    }

    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();

    }

    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
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

}
