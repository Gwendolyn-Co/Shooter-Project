using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask Bounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 8f);
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer != 6){
            Destroy(other.gameObject);
        }
    }
}