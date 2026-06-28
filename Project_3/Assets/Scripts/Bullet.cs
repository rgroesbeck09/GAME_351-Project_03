using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Public variables
    public float speed = 50f;
    public float lifetime = 5f;

    // Private Variables
    private Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Set a collider trigger for the bullet
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bandit"))
        {
            // Get bandit
            BanditScript bandit = other.GetComponent<BanditScript>();

            if (bandit != null)
            {
                bandit.Die();
            }
        }
        
        if(other.CompareTag("Kickable"))
        {
            // get barrel
            BarrelScript barrel = other.GetComponent<BarrelScript>();

            if (barrel != null)
            {
                barrel.explode();
            }    
        }

        // Destory the bullet after it hits bandit
        Destroy(gameObject);
    }
}
