using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Public variables
    public float speed = 25f;
    public float lifetime = 3f;
    
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

            // Destory the bullet after it hits bandit
            Destroy(gameObject);
        }
    }
}
